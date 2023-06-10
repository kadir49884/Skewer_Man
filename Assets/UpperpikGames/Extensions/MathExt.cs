﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upperpik;

public static class MathExt
{
	public static float VectorToRad(this Vector2 thisVec)
	{
		return Mathf.Atan2(thisVec.y, thisVec.x);
	}

	public static Vector2 RadToVector(this float thisFloat)
	{
		return new Vector2(Mathf.Cos(thisFloat), Mathf.Sin(thisFloat));
	}

	public static float VectorToDeg(this Vector2 thisVec)
	{
		return Mathf.Atan2(thisVec.y, thisVec.x) * Mathf.Rad2Deg;
	}

	public static Vector2 DegToVector(this float thisFloat)
	{
		return new Vector2(Mathf.Cos(thisFloat * Mathf.Deg2Rad), Mathf.Sin(thisFloat * Mathf.Deg2Rad));
	}
}
