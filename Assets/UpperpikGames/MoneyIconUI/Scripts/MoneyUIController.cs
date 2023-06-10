using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUIController : Singleton<MoneyUIController>
{
	private Text moneyText;

	private void Awake()
	{
		moneyText = GetComponentInChildren<Text>();
		moneyText.text = PrefManager.GetMoney.ToString();
	}

	public void UpdateMoneyUI(float time = 1, float delay = 0) => moneyText.DOCounter(int.Parse(moneyText.text), PrefManager.GetMoney, time, false).SetDelay(delay);
}
