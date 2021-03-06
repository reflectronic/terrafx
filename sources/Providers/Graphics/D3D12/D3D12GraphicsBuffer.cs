// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Runtime.InteropServices;
using TerraFX.Interop;
using TerraFX.Utilities;
using static TerraFX.Graphics.Providers.D3D12.HelperUtilities;
using static TerraFX.Interop.D3D12;
using static TerraFX.Interop.D3D12_HEAP_FLAGS;
using static TerraFX.Interop.D3D12_HEAP_TYPE;
using static TerraFX.Interop.D3D12_RESOURCE_STATES;
using static TerraFX.Utilities.State;

namespace TerraFX.Graphics.Providers.D3D12
{
    /// <inheritdoc />
    public sealed unsafe class D3D12GraphicsBuffer : GraphicsBuffer
    {
        private ValueLazy<Pointer<ID3D12Resource>> _d3d12Resource;

        private State _state;

        internal D3D12GraphicsBuffer(D3D12GraphicsDevice graphicsDevice, GraphicsBufferKind kind, ulong size, ulong stride)
            : base(graphicsDevice, kind, size, stride)
        {
            _d3d12Resource = new ValueLazy<Pointer<ID3D12Resource>>(CreateD3D12Resource);

            _ = _state.Transition(to: Initialized);
        }

        /// <inheritdoc cref="GraphicsBuffer.GraphicsDevice" />
        public D3D12GraphicsDevice D3D12GraphicsDevice => (D3D12GraphicsDevice)GraphicsDevice;

        /// <summary>Gets the underlying <see cref="ID3D12Resource" /> where the buffer exists.</summary>
        /// <exception cref="ExternalException">The call to <see cref="ID3D12Device.CreateCommittedResource(D3D12_HEAP_PROPERTIES*, D3D12_HEAP_FLAGS, D3D12_RESOURCE_DESC*, D3D12_RESOURCE_STATES, D3D12_CLEAR_VALUE*, Guid*, void**)" /> failed.</exception>
        /// <exception cref="ObjectDisposedException">The buffer has been disposed.</exception>
        public ID3D12Resource* D3D12Resource => _d3d12Resource.Value;

        /// <inheritdoc />
        /// <exception cref="ExternalException">The call to <see cref="ID3D12Resource.Map(uint, D3D12_RANGE*, void**)" /> failed.</exception>
        public override void Write(ReadOnlySpan<byte> bytes)
        {
            var d3d12Resource = D3D12Resource;
            var bytesWritten = bytes.Length;

            var readRange = new D3D12_RANGE();
            var writtenRange = new D3D12_RANGE(UIntPtr.Zero, (UIntPtr)bytesWritten);

            void* pDestination;
            ThrowExternalExceptionIfFailed(nameof(ID3D12Resource.Map), d3d12Resource->Map(Subresource: 0, &readRange, &pDestination));

            var destination = new Span<byte>(pDestination, bytesWritten);
            bytes.CopyTo(destination);

            d3d12Resource->Unmap(Subresource: 0, &writtenRange);
        }

        /// <inheritdoc />
        protected override void Dispose(bool isDisposing)
        {
            var priorState = _state.BeginDispose();

            if (priorState < Disposing)
            {
                _d3d12Resource.Dispose(ReleaseIfNotNull);
            }

            _state.EndDispose();
        }

        private Pointer<ID3D12Resource> CreateD3D12Resource()
        {
            _state.ThrowIfDisposedOrDisposing();

            ID3D12Resource* d3d12Resource;

            var heapProperties = new D3D12_HEAP_PROPERTIES(D3D12_HEAP_TYPE_UPLOAD);
            var bufferDesc = D3D12_RESOURCE_DESC.Buffer(width: Size);
            
            var iid = IID_ID3D12Resource;
            ThrowExternalExceptionIfFailed(nameof(ID3D12Device.CreateCommittedResource), D3D12GraphicsDevice.D3D12Device->CreateCommittedResource(
                &heapProperties,
                D3D12_HEAP_FLAG_NONE,
                &bufferDesc,
                D3D12_RESOURCE_STATE_GENERIC_READ,
                pOptimizedClearValue: null,
                &iid,
                (void**)&d3d12Resource
            ));

            return d3d12Resource;
        }
    }
}
