using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upperpik;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorController : MonoBehaviour
{
	[SerializeField]private Animator animator;

	private AnimationType activeAnimationType;

	private void Awake()
	{
		animator = GetComponentInChildren<Animator>();
	}

	private void Start()
	{
		SetAnimation(AnimationType.Idle);

		GameManager gameManager = GameManager.Instance;
		gameManager.GameStart += Initialize;
	}

	private void Initialize()
	{
		SetAnimation(AnimationType.Running);
	}

	public void SetAnimation(AnimationType type)
	{
		if (activeAnimationType != type)
		{
			activeAnimationType = type;

			if (activeAnimationType.IsRunOrIdle())
				animator.SetBool(UpperUtil.ANIM_RUN, (activeAnimationType == AnimationType.Running) ? true : false);
		}
	}
}
