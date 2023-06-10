using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Upperpik;

public static class PrefManager
{
	private static readonly string PKEY_MUSIC = "Music";

	public static int GetLevel => PlayerPrefs.GetInt(UpperUtil.PKEY_LEVEL, 1);
	public static int GetMoney => PlayerPrefs.GetInt(UpperUtil.PKEY_MONEY, 0);
	public static int GetSound => PlayerPrefs.GetInt(UpperUtil.PKEY_SOUND, 1);
	public static int GetMusic => PlayerPrefs.GetInt(PKEY_MUSIC, 1);
	public static int GetVibration => PlayerPrefs.GetInt(UpperUtil.PKEY_VIBRATION, 1);

	public static void SetMoney(int value) => PlayerPrefs.SetInt(UpperUtil.PKEY_MONEY, value);
	public static void SetLevel(int value) => PlayerPrefs.SetInt(UpperUtil.PKEY_LEVEL, value);

	public static void SetSound(int value) => PlayerPrefs.SetInt(UpperUtil.PKEY_SOUND, value);
	public static void SetMusic(int value) => PlayerPrefs.SetInt(PKEY_MUSIC, value);
	public static void SetVibration(int value) => PlayerPrefs.SetInt(UpperUtil.PKEY_VIBRATION, value);

	public static void ResetLevel() => SetLevel(1);

	public static bool IsByPass => PlayerPrefs.GetInt(UpperUtil.PKEY_BYPASS, 0) == 1;


	public static void ChangeMoney(int value)
	{
		int money = GetMoney + value;
		SetMoney(money);
	}

	public static void IncrementLevel()
	{
		int level = GetLevel;
		SetLevel(level + 1);
	}
	public static void DecrementLevel()
	{
		int level = GetLevel;
		SetLevel(level - 1);
	}
	public static void SetByPass(bool byPass)
	{
		int value = (byPass == true) ? 1 : 0;

		PlayerPrefs.SetInt(UpperUtil.PKEY_BYPASS, value);
	}
}
