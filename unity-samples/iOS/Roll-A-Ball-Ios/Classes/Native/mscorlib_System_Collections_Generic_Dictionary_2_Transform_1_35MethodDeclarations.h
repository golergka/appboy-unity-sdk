﻿#pragma once
#include <stdint.h>
#include <assert.h>
#include <exception>
#include "codegen/il2cpp-codegen.h"

// System.Collections.Generic.Dictionary`2/Transform`1<UnityEngine.UI.ICanvasElement,System.Int32,System.Int32>
struct Transform_1_t3749;
// System.Object
struct Object_t;
// UnityEngine.UI.ICanvasElement
struct ICanvasElement_t551;
// System.IAsyncResult
struct IAsyncResult_t472;
// System.AsyncCallback
struct AsyncCallback_t473;
// System.IntPtr
#include "mscorlib_System_IntPtr.h"

// System.Void System.Collections.Generic.Dictionary`2/Transform`1<UnityEngine.UI.ICanvasElement,System.Int32,System.Int32>::.ctor(System.Object,System.IntPtr)
 void Transform_1__ctor_m19470 (Transform_1_t3749 * __this, Object_t * ___object, IntPtr_t107 ___method, MethodInfo* method) IL2CPP_METHOD_ATTR;
// TRet System.Collections.Generic.Dictionary`2/Transform`1<UnityEngine.UI.ICanvasElement,System.Int32,System.Int32>::Invoke(TKey,TValue)
 int32_t Transform_1_Invoke_m19471 (Transform_1_t3749 * __this, Object_t * ___key, int32_t ___value, MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.IAsyncResult System.Collections.Generic.Dictionary`2/Transform`1<UnityEngine.UI.ICanvasElement,System.Int32,System.Int32>::BeginInvoke(TKey,TValue,System.AsyncCallback,System.Object)
 Object_t * Transform_1_BeginInvoke_m19472 (Transform_1_t3749 * __this, Object_t * ___key, int32_t ___value, AsyncCallback_t473 * ___callback, Object_t * ___object, MethodInfo* method) IL2CPP_METHOD_ATTR;
// TRet System.Collections.Generic.Dictionary`2/Transform`1<UnityEngine.UI.ICanvasElement,System.Int32,System.Int32>::EndInvoke(System.IAsyncResult)
 int32_t Transform_1_EndInvoke_m19473 (Transform_1_t3749 * __this, Object_t * ___result, MethodInfo* method) IL2CPP_METHOD_ATTR;