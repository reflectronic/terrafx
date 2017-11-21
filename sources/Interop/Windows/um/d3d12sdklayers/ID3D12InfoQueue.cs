// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um\d3d12sdklayers.h in the Windows SDK for Windows 10.0.15063.0
// Original source is Copyright © Microsoft. All rights reserved.

using System;
using System.Runtime.InteropServices;
using System.Security;
using static TerraFX.Utilities.InteropUtilities;

namespace TerraFX.Interop
{
    [Guid("0742A90B-C387-483F-B946-30A7E4E61458")]
    public /* blittable */ unsafe struct ID3D12InfoQueue
    {
        #region Fields
        public readonly Vtbl* lpVtbl;
        #endregion

        #region IUnknown Delegates
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _QueryInterface(
            [In] ID3D12InfoQueue* This,
            [In, ComAliasName("REFIID")] Guid* riid,
            [Out] void** ppvObject
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("ULONG")]
        public /* static */ delegate uint _AddRef(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("ULONG")]
        public /* static */ delegate uint _Release(
            [In] ID3D12InfoQueue* This
        );
        #endregion

        #region Delegates
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _SetMessageCountLimit(
            [In] ID3D12InfoQueue* This,
            [In, ComAliasName("UINT64")] ulong MessageCountLimit
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        public /* static */ delegate void _ClearStoredMessages(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetMessage(
            [In] ID3D12InfoQueue* This,
            [In, ComAliasName("UINT64")] ulong MessageIndex,
            [Out, Optional] D3D12_MESSAGE* pMessage,
            [In, Out, ComAliasName("SIZE_T")] nuint* pMessageByteLength
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("UINT64")]
        public /* static */ delegate ulong _GetNumMessagesAllowedByStorageFilter(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("UINT64")]
        public /* static */ delegate ulong _GetNumMessagesDeniedByStorageFilter(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("UINT64")]
        public /* static */ delegate ulong _GetNumStoredMessages(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("UINT64")]
        public /* static */ delegate ulong _GetNumStoredMessagesAllowedByRetrievalFilter(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("UINT64")]
        public /* static */ delegate ulong _GetNumMessagesDiscardedByMessageCountLimit(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("UINT64")]
        public /* static */ delegate ulong _GetMessageCountLimit(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _AddStorageFilterEntries(
            [In] ID3D12InfoQueue* This,
            [In] D3D12_INFO_QUEUE_FILTER* pFilter
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetStorageFilter(
            [In] ID3D12InfoQueue* This,
            [Out, Optional] D3D12_INFO_QUEUE_FILTER* pFilter,
            [In, Out, ComAliasName("SIZE_T")] nuint* pFilterByteLength
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        public /* static */ delegate void _ClearStorageFilter(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _PushEmptyStorageFilter(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _PushCopyOfStorageFilter(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _PushStorageFilter(
            [In] ID3D12InfoQueue* This,
            [In] D3D12_INFO_QUEUE_FILTER* pFilter
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        public /* static */ delegate void _PopStorageFilter(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("UINT")]
        public /* static */ delegate uint _GetStorageFilterStackSize(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _AddRetrievalFilterEntries(
            [In] ID3D12InfoQueue* This,
            [In] D3D12_INFO_QUEUE_FILTER* pFilter
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetRetrievalFilter(
            [In] ID3D12InfoQueue* This,
            [Out, Optional] D3D12_INFO_QUEUE_FILTER* pFilter,
            [In, Out, ComAliasName("SIZE_T")] nuint* pFilterByteLength
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        public /* static */ delegate void _ClearRetrievalFilter(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _PushEmptyRetrievalFilter(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _PushCopyOfRetrievalFilter(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _PushRetrievalFilter(
            [In] ID3D12InfoQueue* This,
            [In] D3D12_INFO_QUEUE_FILTER* pFilter
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        public /* static */ delegate void _PopRetrievalFilter(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("UINT")]
        public /* static */ delegate uint _GetRetrievalFilterStackSize(
            [In] ID3D12InfoQueue* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _AddMessage(
            [In] ID3D12InfoQueue* This,
            [In] D3D12_MESSAGE_CATEGORY Category,
            [In] D3D12_MESSAGE_SEVERITY Severity,
            [In] D3D12_MESSAGE_ID ID,
            [In, ComAliasName("LPCSTR")] sbyte* pDescription
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _AddApplicationMessage(
            [In] ID3D12InfoQueue* This,
            [In] D3D12_MESSAGE_SEVERITY Severity,
            [In, ComAliasName("LPCSTR")] sbyte* pDescription
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _SetBreakOnCategory(
            [In] ID3D12InfoQueue* This,
            [In] D3D12_MESSAGE_CATEGORY Category,
            [In, ComAliasName("BOOL")] int bEnable
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _SetBreakOnSeverity(
            [In] ID3D12InfoQueue* This,
            [In] D3D12_MESSAGE_SEVERITY Severity,
            [In, ComAliasName("BOOL")] int bEnable
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _SetBreakOnID(
            [In] ID3D12InfoQueue* This,
            [In] D3D12_MESSAGE_ID ID,
            [In, ComAliasName("BOOL")] int bEnable
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("BOOL")]
        public /* static */ delegate int _GetBreakOnCategory(
            [In] ID3D12InfoQueue* This,
            [In] D3D12_MESSAGE_CATEGORY Category
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("BOOL")]
        public /* static */ delegate int _GetBreakOnSeverity(
            [In] ID3D12InfoQueue* This,
            [In] D3D12_MESSAGE_SEVERITY Severity
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("BOOL")]
        public /* static */ delegate int _GetBreakOnID(
            [In] ID3D12InfoQueue* This,
            [In] D3D12_MESSAGE_ID ID
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        public /* static */ delegate void _SetMuteDebugOutput(
            [In] ID3D12InfoQueue* This,
            [In, ComAliasName("BOOL")] int bMute
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("BOOL")]
        public /* static */ delegate int _GetMuteDebugOutput(
            [In] ID3D12InfoQueue* This
        );
        #endregion

        #region IUnknown Methods
        [return: ComAliasName("HRESULT")]
        public int QueryInterface(
            [In, ComAliasName("REFIID")] Guid* riid,
            [Out] void** ppvObject
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_QueryInterface>(lpVtbl->QueryInterface)(
                    This,
                    riid,
                    ppvObject
                );
            }
        }

        [return: ComAliasName("ULONG")]
        public uint AddRef()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_AddRef>(lpVtbl->AddRef)(
                    This
                );
            }
        }

        [return: ComAliasName("ULONG")]
        public uint Release()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_Release>(lpVtbl->Release)(
                    This
                );
            }
        }
        #endregion

        #region Methods
        [return: ComAliasName("HRESULT")]
        public int SetMessageCountLimit(
            [In, ComAliasName("UINT64")] ulong MessageCountLimit
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_SetMessageCountLimit>(lpVtbl->SetMessageCountLimit)(
                    This,
                    MessageCountLimit
                );
            }
        }

        public void ClearStoredMessages()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                MarshalFunction<_ClearStoredMessages>(lpVtbl->ClearStoredMessages)(
                    This
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetMessage(
            [In, ComAliasName("UINT64")] ulong MessageIndex,
            [Out, Optional] D3D12_MESSAGE* pMessage,
            [In, Out, ComAliasName("SIZE_T")] nuint* pMessageByteLength
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_GetMessage>(lpVtbl->GetMessage)(
                    This,
                    MessageIndex,
                    pMessage,
                    pMessageByteLength
                );
            }
        }

        [return: ComAliasName("UINT64")]
        public ulong GetNumMessagesAllowedByStorageFilter()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_GetNumMessagesAllowedByStorageFilter>(lpVtbl->GetNumMessagesAllowedByStorageFilter)(
                    This
                );
            }
        }

        [return: ComAliasName("UINT64")]
        public ulong GetNumMessagesDeniedByStorageFilter()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_GetNumMessagesDeniedByStorageFilter>(lpVtbl->GetNumMessagesDeniedByStorageFilter)(
                    This
                );
            }
        }

        [return: ComAliasName("UINT64")]
        public ulong GetNumStoredMessages()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_GetNumStoredMessages>(lpVtbl->GetNumStoredMessages)(
                    This
                );
            }
        }

        [return: ComAliasName("UINT64")]
        public ulong GetNumStoredMessagesAllowedByRetrievalFilter()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_GetNumStoredMessagesAllowedByRetrievalFilter>(lpVtbl->GetNumStoredMessagesAllowedByRetrievalFilter)(
                    This
                );
            }
        }

        [return: ComAliasName("UINT64")]
        public ulong GetNumMessagesDiscardedByMessageCountLimit()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_GetNumMessagesDiscardedByMessageCountLimit>(lpVtbl->GetNumMessagesDiscardedByMessageCountLimit)(
                    This
                );
            }
        }

        [return: ComAliasName("UINT64")]
        public ulong GetMessageCountLimit()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_GetMessageCountLimit>(lpVtbl->GetMessageCountLimit)(
                    This
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int AddStorageFilterEntries(
            [In] D3D12_INFO_QUEUE_FILTER* pFilter
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_AddStorageFilterEntries>(lpVtbl->AddStorageFilterEntries)(
                    This,
                    pFilter
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetStorageFilter(
            [Out, Optional] D3D12_INFO_QUEUE_FILTER* pFilter,
            [In, Out, ComAliasName("SIZE_T")] nuint* pFilterByteLength
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_GetStorageFilter>(lpVtbl->GetStorageFilter)(
                    This,
                    pFilter,
                    pFilterByteLength
                );
            }
        }

        public void ClearStorageFilter()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                MarshalFunction<_ClearStorageFilter>(lpVtbl->ClearStorageFilter)(
                    This
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int PushEmptyStorageFilter()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_PushEmptyStorageFilter>(lpVtbl->PushEmptyStorageFilter)(
                    This
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int PushCopyOfStorageFilter()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_PushCopyOfStorageFilter>(lpVtbl->PushCopyOfStorageFilter)(
                    This
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int PushStorageFilter(
            [In] D3D12_INFO_QUEUE_FILTER* pFilter
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_PushStorageFilter>(lpVtbl->PushStorageFilter)(
                    This,
                    pFilter
                );
            }
        }

        public void PopStorageFilter()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                MarshalFunction<_PopStorageFilter>(lpVtbl->PopStorageFilter)(
                    This
                );
            }
        }

        [return: ComAliasName("UINT")]
        public uint GetStorageFilterStackSize()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_GetStorageFilterStackSize>(lpVtbl->GetStorageFilterStackSize)(
                    This
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int AddRetrievalFilterEntries(
            [In] D3D12_INFO_QUEUE_FILTER* pFilter
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_AddRetrievalFilterEntries>(lpVtbl->AddRetrievalFilterEntries)(
                    This,
                    pFilter
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetRetrievalFilter(
            [Out, Optional] D3D12_INFO_QUEUE_FILTER* pFilter,
            [In, Out, ComAliasName("SIZE_T")] nuint* pFilterByteLength
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_GetRetrievalFilter>(lpVtbl->GetRetrievalFilter)(
                    This,
                    pFilter,
                    pFilterByteLength
                );
            }
        }

        public void ClearRetrievalFilter()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                MarshalFunction<_ClearRetrievalFilter>(lpVtbl->ClearRetrievalFilter)(
                    This
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int PushEmptyRetrievalFilter()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_PushEmptyRetrievalFilter>(lpVtbl->PushEmptyRetrievalFilter)(
                    This
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int PushCopyOfRetrievalFilter()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_PushCopyOfRetrievalFilter>(lpVtbl->PushCopyOfRetrievalFilter)(
                    This
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int PushRetrievalFilter(
            [In] D3D12_INFO_QUEUE_FILTER* pFilter
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_PushRetrievalFilter>(lpVtbl->PushRetrievalFilter)(
                    This,
                    pFilter
                );
            }
        }

        public void PopRetrievalFilter()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                MarshalFunction<_PopRetrievalFilter>(lpVtbl->PopRetrievalFilter)(
                    This
                );
            }
        }

        [return: ComAliasName("UINT")]
        public uint GetRetrievalFilterStackSize()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_GetRetrievalFilterStackSize>(lpVtbl->GetRetrievalFilterStackSize)(
                    This
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int AddMessage(
            [In] D3D12_MESSAGE_CATEGORY Category,
            [In] D3D12_MESSAGE_SEVERITY Severity,
            [In] D3D12_MESSAGE_ID ID,
            [In, ComAliasName("LPCSTR")] sbyte* pDescription
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_AddMessage>(lpVtbl->AddMessage)(
                    This,
                    Category,
                    Severity,
                    ID,
                    pDescription
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int AddApplicationMessage(
            [In] D3D12_MESSAGE_SEVERITY Severity,
            [In, ComAliasName("LPCSTR")] sbyte* pDescription
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_AddApplicationMessage>(lpVtbl->AddApplicationMessage)(
                    This,
                    Severity,
                    pDescription
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int SetBreakOnCategory(
            [In] D3D12_MESSAGE_CATEGORY Category,
            [In, ComAliasName("BOOL")] int bEnable
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_SetBreakOnCategory>(lpVtbl->SetBreakOnCategory)(
                    This,
                    Category,
                    bEnable
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int SetBreakOnSeverity(
            [In] D3D12_MESSAGE_SEVERITY Severity,
            [In, ComAliasName("BOOL")] int bEnable
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_SetBreakOnSeverity>(lpVtbl->SetBreakOnSeverity)(
                    This,
                    Severity,
                    bEnable
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int SetBreakOnID(
            [In] D3D12_MESSAGE_ID ID,
            [In, ComAliasName("BOOL")] int bEnable
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_SetBreakOnID>(lpVtbl->SetBreakOnID)(
                    This,
                    ID,
                    bEnable
                );
            }
        }

        [return: ComAliasName("BOOL")]
        public int GetBreakOnCategory(
            [In] D3D12_MESSAGE_CATEGORY Category
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_GetBreakOnCategory>(lpVtbl->GetBreakOnCategory)(
                    This,
                    Category
                );
            }
        }

        [return: ComAliasName("BOOL")]
        public int GetBreakOnSeverity(
            [In] D3D12_MESSAGE_SEVERITY Severity
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_GetBreakOnSeverity>(lpVtbl->GetBreakOnSeverity)(
                    This,
                    Severity
                );
            }
        }

        [return: ComAliasName("BOOL")]
        public int GetBreakOnID(
            [In] D3D12_MESSAGE_ID ID
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_GetBreakOnID>(lpVtbl->GetBreakOnID)(
                    This,
                    ID
                );
            }
        }

        public void SetMuteDebugOutput(
            [In, ComAliasName("BOOL")] int bMute
        )
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                MarshalFunction<_SetMuteDebugOutput>(lpVtbl->SetMuteDebugOutput)(
                    This,
                    bMute
                );
            }
        }

        [return: ComAliasName("BOOL")]
        public int GetMuteDebugOutput()
        {
            fixed (ID3D12InfoQueue* This = &this)
            {
                return MarshalFunction<_GetMuteDebugOutput>(lpVtbl->GetMuteDebugOutput)(
                    This
                );
            }
        }
        #endregion

        #region Structs
        public /* blittable */ struct Vtbl
        {
            #region IUnknown Fields
            public IntPtr QueryInterface;

            public IntPtr AddRef;

            public IntPtr Release;
            #endregion

            #region Fields
            public IntPtr SetMessageCountLimit;

            public IntPtr ClearStoredMessages;

            public IntPtr GetMessage;

            public IntPtr GetNumMessagesAllowedByStorageFilter;

            public IntPtr GetNumMessagesDeniedByStorageFilter;

            public IntPtr GetNumStoredMessages;

            public IntPtr GetNumStoredMessagesAllowedByRetrievalFilter;

            public IntPtr GetNumMessagesDiscardedByMessageCountLimit;

            public IntPtr GetMessageCountLimit;

            public IntPtr AddStorageFilterEntries;

            public IntPtr GetStorageFilter;

            public IntPtr ClearStorageFilter;

            public IntPtr PushEmptyStorageFilter;

            public IntPtr PushCopyOfStorageFilter;

            public IntPtr PushStorageFilter;

            public IntPtr PopStorageFilter;

            public IntPtr GetStorageFilterStackSize;

            public IntPtr AddRetrievalFilterEntries;

            public IntPtr GetRetrievalFilter;

            public IntPtr ClearRetrievalFilter;

            public IntPtr PushEmptyRetrievalFilter;

            public IntPtr PushCopyOfRetrievalFilter;

            public IntPtr PushRetrievalFilter;

            public IntPtr PopRetrievalFilter;

            public IntPtr GetRetrievalFilterStackSize;

            public IntPtr AddMessage;

            public IntPtr AddApplicationMessage;

            public IntPtr SetBreakOnCategory;

            public IntPtr SetBreakOnSeverity;

            public IntPtr SetBreakOnID;

            public IntPtr GetBreakOnCategory;

            public IntPtr GetBreakOnSeverity;

            public IntPtr GetBreakOnID;

            public IntPtr SetMuteDebugOutput;

            public IntPtr GetMuteDebugOutput;
            #endregion
        }
        #endregion
    }
}
