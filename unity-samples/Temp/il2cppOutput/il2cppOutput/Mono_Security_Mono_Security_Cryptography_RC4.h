﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

// System.Security.Cryptography.KeySizes[]
struct KeySizesU5BU5D_t1257;

#include "mscorlib_System_Security_Cryptography_SymmetricAlgorithm.h"

// Mono.Security.Cryptography.RC4
struct  RC4_t1275  : public SymmetricAlgorithm_t1239
{
};
struct RC4_t1275_StaticFields{
	// System.Security.Cryptography.KeySizes[] Mono.Security.Cryptography.RC4::s_legalBlockSizes
	KeySizesU5BU5D_t1257* ___s_legalBlockSizes_10;
	// System.Security.Cryptography.KeySizes[] Mono.Security.Cryptography.RC4::s_legalKeySizes
	KeySizesU5BU5D_t1257* ___s_legalKeySizes_11;
};
