﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

// System.String
struct String_t;
// System.Collections.Generic.HashSet`1<Appboy.Models.CardCategory>
struct HashSet_1_t38;

#include "mscorlib_System_Object.h"

// Appboy.Models.Cards.Card
struct  Card_t36  : public Object_t
{
	// System.String Appboy.Models.Cards.Card::<ID>k__BackingField
	String_t* ___U3CIDU3Ek__BackingField_0;
	// System.String Appboy.Models.Cards.Card::<Type>k__BackingField
	String_t* ___U3CTypeU3Ek__BackingField_1;
	// System.Boolean Appboy.Models.Cards.Card::<Viewed>k__BackingField
	bool ___U3CViewedU3Ek__BackingField_2;
	// System.Int64 Appboy.Models.Cards.Card::<Created>k__BackingField
	int64_t ___U3CCreatedU3Ek__BackingField_3;
	// System.Int64 Appboy.Models.Cards.Card::<Updated>k__BackingField
	int64_t ___U3CUpdatedU3Ek__BackingField_4;
	// System.Collections.Generic.HashSet`1<Appboy.Models.CardCategory> Appboy.Models.Cards.Card::<Categories>k__BackingField
	HashSet_1_t38 * ___U3CCategoriesU3Ek__BackingField_5;
	// System.String Appboy.Models.Cards.Card::<JsonString>k__BackingField
	String_t* ___U3CJsonStringU3Ek__BackingField_6;
};
