// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using TerraFX.Interop;
using TerraFX.Numerics;
using TerraFX.Utilities;
using static TerraFX.Graphics.Providers.D3D12.HelperUtilities;
using static TerraFX.Interop.D3D12;
using static TerraFX.Interop.D3D12_PRIMITIVE_TOPOLOGY_TYPE;
using static TerraFX.Interop.DXGI_FORMAT;
using static TerraFX.Interop.Windows;
using static TerraFX.Utilities.DisposeUtilities;
using static TerraFX.Utilities.State;

namespace TerraFX.Graphics.Providers.D3D12
{
    /// <inheritdoc />
    public sealed unsafe class D3D12GraphicsPipeline : GraphicsPipeline
    {
        private ValueLazy<Pointer<ID3D12PipelineState>> _d3d12PipelineState;

        private State _state;

        internal D3D12GraphicsPipeline(D3D12GraphicsDevice graphicsDevice, D3D12GraphicsPipelineSignature signature, D3D12GraphicsShader? vertexShader, D3D12GraphicsShader? pixelShader)
            : base(graphicsDevice, signature, vertexShader, pixelShader)
        {
            _d3d12PipelineState = new ValueLazy<Pointer<ID3D12PipelineState>>(CreateD3D12GraphicsPipelineState);

            _ = _state.Transition(to: Initialized);
        }

        /// <summary>Finalizes an instance of the <see cref="D3D12GraphicsPipeline" /> class.</summary>
        ~D3D12GraphicsPipeline()
        {
            Dispose(isDisposing: false);
        }

        // COLOR
        private static ReadOnlySpan<sbyte> COLOR_SEMANTIC_NAME => new sbyte[] { 0x43, 0x4F, 0x4C, 0x4F, 0x52, 0x00 };

        // POSITION
        private static ReadOnlySpan<sbyte> POSITION_SEMANTIC_NAME => new sbyte[] { 0x50, 0x4F, 0x53, 0x49, 0x54, 0x49, 0x4F, 0x4E, 0x00 };

        /// <inheritdoc cref="GraphicsPipeline.GraphicsDevice" />
        public D3D12GraphicsDevice D3D12GraphicsDevice => (D3D12GraphicsDevice)GraphicsDevice;

        /// <summary>Gets the underlying <see cref="ID3D12PipelineState" /> for the pipeline.</summary>
        public ID3D12PipelineState* D3D12PipelineState => _d3d12PipelineState.Value;

        /// <inheritdoc cref="GraphicsPipeline.PixelShader" />
        public D3D12GraphicsShader? D3D12PixelShader => (D3D12GraphicsShader?)PixelShader;

        /// <inheritdoc cref="GraphicsPipeline.Signature" />
        public D3D12GraphicsPipelineSignature D3D12Signature => (D3D12GraphicsPipelineSignature)Signature;

        /// <inheritdoc cref="GraphicsPipeline.VertexShader" />
        public D3D12GraphicsShader? D3D12VertexShader => (D3D12GraphicsShader?)VertexShader;

        /// <inheritdoc />
        protected override void Dispose(bool isDisposing)
        {
            var priorState = _state.BeginDispose();

            if (priorState < Disposing)
            {
                _d3d12PipelineState.Dispose(ReleaseIfNotNull);

                DisposeIfNotNull(Signature);
                DisposeIfNotNull(PixelShader);
                DisposeIfNotNull(VertexShader);
            }

            _state.EndDispose();
        }

        private Pointer<ID3D12PipelineState> CreateD3D12GraphicsPipelineState()
        {
            _state.ThrowIfDisposedOrDisposing();

            ID3D12PipelineState* d3d12GraphicsPipelineState;

            var inputElementDescs = Array.Empty<D3D12_INPUT_ELEMENT_DESC>();

            var graphicsPipelineStateDesc = new D3D12_GRAPHICS_PIPELINE_STATE_DESC {
                pRootSignature = D3D12Signature.D3D12RootSignature,
                RasterizerState = D3D12_RASTERIZER_DESC.DEFAULT,
                BlendState = D3D12_BLEND_DESC.DEFAULT,
                DepthStencilState = D3D12_DEPTH_STENCIL_DESC.DEFAULT,
                SampleMask = uint.MaxValue,
                PrimitiveTopologyType = D3D12_PRIMITIVE_TOPOLOGY_TYPE_TRIANGLE,
                NumRenderTargets = 1,
                SampleDesc = new DXGI_SAMPLE_DESC(count: 1, quality: 0),
            };
            graphicsPipelineStateDesc.DepthStencilState.DepthEnable = FALSE;
            graphicsPipelineStateDesc.RTVFormats[0] = D3D12GraphicsDevice.DxgiSwapChainFormat;

            var vertexShader = D3D12VertexShader;

            if (vertexShader != null)
            {
                var inputs = D3D12Signature.Inputs;
                var inputsLength = inputs.Length;

                var inputElementsCount = GetInputElementsCount(inputs);
                var inputElementsIndex = 0;

                var inputSlotIndex = 0;

                if (inputElementsCount != 0)
                {
                    inputElementDescs = new D3D12_INPUT_ELEMENT_DESC[inputElementsCount];

                    for (var inputIndex = 0; inputIndex < inputsLength; inputIndex++)
                    {
                        var input = inputs[inputIndex];

                        var inputElements = input.Elements;
                        var inputElementsLength = inputElements.Length;

                        uint inputLayoutStride = 0;

                        for (var inputElementIndex = 0; inputElementIndex < inputElementsLength; inputElementIndex++)
                        {
                            var inputElement = inputElements[inputElementIndex];

                            inputElementDescs[inputElementsIndex] = new D3D12_INPUT_ELEMENT_DESC {
                                SemanticName = GetInputElementSemanticName(inputElement.Kind).AsPointer(),
                                Format = GetInputElementFormat(inputElement.Type),
                                InputSlot = unchecked((uint)inputSlotIndex),
                                AlignedByteOffset = inputLayoutStride,
                            };

                            inputLayoutStride += inputElement.Size;
                            inputElementsIndex++;
                        }
                        inputSlotIndex++;
                    }
                }

                graphicsPipelineStateDesc.VS = vertexShader.D3D12ShaderBytecode;
            }

            var pixelShader = D3D12PixelShader;

            if (pixelShader != null)
            {
                graphicsPipelineStateDesc.PS = pixelShader.D3D12ShaderBytecode;
            }

            fixed (D3D12_INPUT_ELEMENT_DESC* pInputElementDescs = inputElementDescs)
            {
                graphicsPipelineStateDesc.InputLayout = new D3D12_INPUT_LAYOUT_DESC {
                    pInputElementDescs = pInputElementDescs,
                    NumElements = unchecked((uint)inputElementDescs.Length),
                };

                var iid = IID_ID3D12PipelineState;
                ThrowExternalExceptionIfFailed(nameof(ID3D12Device.CreateGraphicsPipelineState), D3D12GraphicsDevice.D3D12Device->CreateGraphicsPipelineState(&graphicsPipelineStateDesc, &iid, (void**)&d3d12GraphicsPipelineState));
            }
            return d3d12GraphicsPipelineState;

            static int GetInputElementsCount(ReadOnlySpan<GraphicsPipelineInput> inputs)
            {
                var inputElementsCount = 0;

                foreach (var input in inputs)
                {
                    inputElementsCount += input.Elements.Length;
                }

                return inputElementsCount;
            }
        }

        private DXGI_FORMAT GetInputElementFormat(Type type)
        {
            var inputElementFormat = DXGI_FORMAT_UNKNOWN;

            if (type == typeof(Vector2))
            {
                inputElementFormat = DXGI_FORMAT_R32G32_FLOAT;
            }
            else if (type == typeof(Vector3))
            {
                inputElementFormat = DXGI_FORMAT_R32G32B32_FLOAT;
            }
            else if (type == typeof(Vector4))
            {
                inputElementFormat = DXGI_FORMAT_R32G32B32A32_FLOAT;
            }

            return inputElementFormat;
        }

        private ReadOnlySpan<sbyte> GetInputElementSemanticName(GraphicsPipelineInputElementKind inputElementKind)
        {
            ReadOnlySpan<sbyte> inputElementSemanticName;

            switch (inputElementKind)
            {
                case GraphicsPipelineInputElementKind.Position:
                {
                    inputElementSemanticName = POSITION_SEMANTIC_NAME;
                    break;
                }

                case GraphicsPipelineInputElementKind.Color:
                {
                    inputElementSemanticName = COLOR_SEMANTIC_NAME;
                    break;
                }

                default:
                {
                    inputElementSemanticName = default;
                    break;
                }
            }

            return inputElementSemanticName;
        }
    }
}
