using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationType
{
	Idle,
	Running,
}

public static class UpperEnum
{
	public static bool IsRunOrIdle(this AnimationType type) => type == AnimationType.Idle || type == AnimationType.Running;

}
