using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : Singleton<CanvasManager>
{
	[SerializeField] private Text levelText;
	[SerializeField] private Text moneyText;

	[SerializeField] private GameObject confetti;
	[SerializeField] private GameObject moneyArea;

	private void Start()
	{
		if (levelText != null & moneyText != null)
			InitializeLevelTexts();

		if (moneyArea != null)
			ActivateMoneyArea(false);
	}

	public void InitializeLevelTexts()
	{
		levelText.text = "Lv." + PrefManager.GetLevel;
		moneyText.text = "$" + PrefManager.GetMoney;
	}

	public void Confetti() => confetti.SetActive(true);

	public void ActivateMoneyArea(bool active) => moneyArea.SetActive(active);
}
