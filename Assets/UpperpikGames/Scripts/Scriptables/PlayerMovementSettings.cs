using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upperpik;

[CreateAssetMenu(menuName = "Upperpik/Player/MovementSettings")]
public class PlayerMovementSettings : ScriptableObject
{
	[SerializeField] private float forwardSpeed;
	[SerializeField] private float sensitivity;

	public float ForwardSpeed => forwardSpeed;
	public float Sensitivity => sensitivity;
}
