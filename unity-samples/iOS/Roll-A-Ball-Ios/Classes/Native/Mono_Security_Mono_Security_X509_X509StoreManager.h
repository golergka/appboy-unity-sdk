﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

// Mono.Security.X509.X509Stores
struct X509Stores_t1201;

#include "mscorlib_System_Object.h"

// Mono.Security.X509.X509StoreManager
struct  X509StoreManager_t1291  : public Object_t
{
};
struct X509StoreManager_t1291_StaticFields{
	// Mono.Security.X509.X509Stores Mono.Security.X509.X509StoreManager::_userStore
	X509Stores_t1201 * ____userStore_0;
	// Mono.Security.X509.X509Stores Mono.Security.X509.X509StoreManager::_machineStore
	X509Stores_t1201 * ____machineStore_1;
};
