/*
* FileName: SceneBuild 
* Author: AppleCoffee 
* CreateTime: 2021-01-12-15:35:47 
*/

using UnityEngine;
using System;
using System.Collections.Generic;

public interface ISceneBuildView
{
	void GetSceneBuildSuccess<T>(T data, Action<T> action);

	void GetSceneBuildFail(string failMsg, Action action);
}