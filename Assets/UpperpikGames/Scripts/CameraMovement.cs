using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upperpik;

public class CameraMovement : MonoBehaviour
{

	[SerializeField] private Transform target;
	[SerializeField] private Vector3 offset;
	[SerializeField] private float lerpTime = .1f;

	private void Start()
	{
		GameManager gameManager = GameManager.Instance;

		gameManager.GameWin += GameWin;
		gameManager.GameFail += GameFail;

	}

	void FixedUpdate()
	{
		if (target)
			transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpTime);
	}


	private void GameWin()
	{
		//	TODO 
	}
	private void GameFail()
	{
		// TODO
	}
}
