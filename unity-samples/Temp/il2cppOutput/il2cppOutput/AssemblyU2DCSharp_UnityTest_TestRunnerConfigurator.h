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

#include "mscorlib_System_Object.h"

// UnityTest.TestRunnerConfigurator
struct  TestRunnerConfigurator_t243  : public Object_t
{
	// System.Boolean UnityTest.TestRunnerConfigurator::<isBatchRun>k__BackingField
	bool ___U3CisBatchRunU3Ek__BackingField_3;
	// System.Boolean UnityTest.TestRunnerConfigurator::<sendResultsOverNetwork>k__BackingField
	bool ___U3CsendResultsOverNetworkU3Ek__BackingField_4;
};
struct TestRunnerConfigurator_t243_StaticFields{
	// System.String UnityTest.TestRunnerConfigurator::integrationTestsNetwork
	String_t* ___integrationTestsNetwork_0;
	// System.String UnityTest.TestRunnerConfigurator::batchRunFileMarker
	String_t* ___batchRunFileMarker_1;
	// System.String UnityTest.TestRunnerConfigurator::testScenesToRun
	String_t* ___testScenesToRun_2;
};
