﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>
#include <assert.h>
#include <exception>

// System.Comparison`1<UnityEngine.RaycastHit>
struct Comparison_1_t480;
// System.Object
struct Object_t;
// System.IAsyncResult
struct IAsyncResult_t551;
// System.AsyncCallback
struct AsyncCallback_t552;

#include "codegen/il2cpp-codegen.h"
#include "mscorlib_System_IntPtr.h"
#include "UnityEngine_UnityEngine_RaycastHit.h"

// System.Void System.Comparison`1<UnityEngine.RaycastHit>::.ctor(System.Object,System.IntPtr)
extern "C" void Comparison_1__ctor_m3260_gshared (Comparison_1_t480 * __this, Object_t * ___object, IntPtr_t ___method, const MethodInfo* method);
#define Comparison_1__ctor_m3260(__this, ___object, ___method, method) (( void (*) (Comparison_1_t480 *, Object_t *, IntPtr_t, const MethodInfo*))Comparison_1__ctor_m3260_gshared)(__this, ___object, ___method, method)
// System.Int32 System.Comparison`1<UnityEngine.RaycastHit>::Invoke(T,T)
extern "C" int32_t Comparison_1_Invoke_m16291_gshared (Comparison_1_t480 * __this, RaycastHit_t407  ___x, RaycastHit_t407  ___y, const MethodInfo* method);
#define Comparison_1_Invoke_m16291(__this, ___x, ___y, method) (( int32_t (*) (Comparison_1_t480 *, RaycastHit_t407 , RaycastHit_t407 , const MethodInfo*))Comparison_1_Invoke_m16291_gshared)(__this, ___x, ___y, method)
// System.IAsyncResult System.Comparison`1<UnityEngine.RaycastHit>::BeginInvoke(T,T,System.AsyncCallback,System.Object)
extern "C" Object_t * Comparison_1_BeginInvoke_m16292_gshared (Comparison_1_t480 * __this, RaycastHit_t407  ___x, RaycastHit_t407  ___y, AsyncCallback_t552 * ___callback, Object_t * ___object, const MethodInfo* method);
#define Comparison_1_BeginInvoke_m16292(__this, ___x, ___y, ___callback, ___object, method) (( Object_t * (*) (Comparison_1_t480 *, RaycastHit_t407 , RaycastHit_t407 , AsyncCallback_t552 *, Object_t *, const MethodInfo*))Comparison_1_BeginInvoke_m16292_gshared)(__this, ___x, ___y, ___callback, ___object, method)
// System.Int32 System.Comparison`1<UnityEngine.RaycastHit>::EndInvoke(System.IAsyncResult)
extern "C" int32_t Comparison_1_EndInvoke_m16293_gshared (Comparison_1_t480 * __this, Object_t * ___result, const MethodInfo* method);
#define Comparison_1_EndInvoke_m16293(__this, ___result, method) (( int32_t (*) (Comparison_1_t480 *, Object_t *, const MethodInfo*))Comparison_1_EndInvoke_m16293_gshared)(__this, ___result, method)
