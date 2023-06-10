using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upperpik;

public static class TweenExt
{
	public static void DoResize(this LineRenderer line, float startWidth, float endWidth, float time, Ease ease = Ease.Linear)
	{
		DOTween.To((value) => { line.startWidth = value; }, line.startWidth, startWidth, time).SetEase(ease);
		DOTween.To((value) => { line.endWidth = value; }, line.endWidth, endWidth, time).SetEase(ease);
	}
}
