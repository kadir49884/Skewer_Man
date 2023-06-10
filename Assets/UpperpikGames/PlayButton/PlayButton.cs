using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
	void Start()
	{
		//if (!PrefManager.IsByPass)
			GetComponent<Button>().onClick.AddListener(ButtonClick);
		//else
			//ButtonClick();
	}
	private void ButtonClick()
	{
		PrefManager.SetByPass(false);
		gameObject.SetActive(false);
		//GameManager.instance.Initialize();
		GameManager.Instance.GameStart();
	}
}
