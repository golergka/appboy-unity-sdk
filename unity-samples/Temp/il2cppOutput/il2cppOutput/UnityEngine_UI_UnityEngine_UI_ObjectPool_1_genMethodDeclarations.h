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


#include "codegen/il2cpp-codegen.h"
#include "UnityEngine_UI_UnityEngine_UI_ObjectPool_1_gen_1MethodDeclarations.h"

// System.Void UnityEngine.UI.ObjectPool`1<System.Collections.Generic.List`1<UnityEngine.EventSystems.IEventSystemHandler>>::.ctor(UnityEngine.Events.UnityAction`1<T>,UnityEngine.Events.UnityAction`1<T>)
#define ObjectPool_1__ctor_m3188(__this, ___actionOnGet, ___actionOnRelease, method) (( void (*) (ObjectPool_1_t454 *, UnityAction_1_t456 *, UnityAction_1_t456 *, const MethodInfo*))ObjectPool_1__ctor_m15212_gshared)(__this, ___actionOnGet, ___actionOnRelease, method)
// System.Int32 UnityEngine.UI.ObjectPool`1<System.Collections.Generic.List`1<UnityEngine.EventSystems.IEventSystemHandler>>::get_countAll()
#define ObjectPool_1_get_countAll_m15213(__this, method) (( int32_t (*) (ObjectPool_1_t454 *, const MethodInfo*))ObjectPool_1_get_countAll_m15214_gshared)(__this, method)
// System.Void UnityEngine.UI.ObjectPool`1<System.Collections.Generic.List`1<UnityEngine.EventSystems.IEventSystemHandler>>::set_countAll(System.Int32)
#define ObjectPool_1_set_countAll_m15215(__this, ___value, method) (( void (*) (ObjectPool_1_t454 *, int32_t, const MethodInfo*))ObjectPool_1_set_countAll_m15216_gshared)(__this, ___value, method)
// System.Int32 UnityEngine.UI.ObjectPool`1<System.Collections.Generic.List`1<UnityEngine.EventSystems.IEventSystemHandler>>::get_countActive()
#define ObjectPool_1_get_countActive_m15217(__this, method) (( int32_t (*) (ObjectPool_1_t454 *, const MethodInfo*))ObjectPool_1_get_countActive_m15218_gshared)(__this, method)
// System.Int32 UnityEngine.UI.ObjectPool`1<System.Collections.Generic.List`1<UnityEngine.EventSystems.IEventSystemHandler>>::get_countInactive()
#define ObjectPool_1_get_countInactive_m15219(__this, method) (( int32_t (*) (ObjectPool_1_t454 *, const MethodInfo*))ObjectPool_1_get_countInactive_m15220_gshared)(__this, method)
// T UnityEngine.UI.ObjectPool`1<System.Collections.Generic.List`1<UnityEngine.EventSystems.IEventSystemHandler>>::Get()
#define ObjectPool_1_Get_m15221(__this, method) (( List_1_t642 * (*) (ObjectPool_1_t454 *, const MethodInfo*))ObjectPool_1_Get_m15222_gshared)(__this, method)
// System.Void UnityEngine.UI.ObjectPool`1<System.Collections.Generic.List`1<UnityEngine.EventSystems.IEventSystemHandler>>::Release(T)
#define ObjectPool_1_Release_m15223(__this, ___element, method) (( void (*) (ObjectPool_1_t454 *, List_1_t642 *, const MethodInfo*))ObjectPool_1_Release_m15224_gshared)(__this, ___element, method)