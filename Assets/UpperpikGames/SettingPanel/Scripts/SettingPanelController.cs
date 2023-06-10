using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MoreMountains.NiceVibrations;
using Sirenix.OdinInspector;
using Upperpik;

#if UNITY_IOS
using UnityEngine.iOS;
#endif
public class SettingPanelController : Singleton<SettingPanelController>
{
	[SerializeField] private GameObject settingMenuPanel;

	[SerializeField, FoldoutGroup("Sound")] private GameObject soundButton;
	[SerializeField, FoldoutGroup("Sound")] private Sprite soundOnSprite;
	[SerializeField, FoldoutGroup("Sound")] private Sprite soundOffSprite;
	[SerializeField, FoldoutGroup("Sound")] private Text soundText;

	[SerializeField, FoldoutGroup("Music")] private GameObject musicButton;
	[SerializeField, FoldoutGroup("Music")] private Sprite musicOnSprite;
	[SerializeField, FoldoutGroup("Music")] private Sprite musicOffSprite;
	[SerializeField, FoldoutGroup("Music")] private Text musicText;

	[SerializeField, FoldoutGroup("Vibrate")] private GameObject vibrateButton;
	[SerializeField, FoldoutGroup("Vibrate")] private Sprite vibrateOnSprite;
	[SerializeField, FoldoutGroup("Vibrate")] private Sprite vibrateOffSprite;
	[SerializeField, FoldoutGroup("Vibrate")] private Text vibrationText;

	[SerializeField, FoldoutGroup("RestorePurchaseButton")] private Text restoreButtonText;
	[SerializeField, FoldoutGroup("RestorePurchaseButton")] public RectTransform restoreButtonRect;

	[SerializeField] private Button settingBackGround;
	[SerializeField] private GameObject settingPanel;


	public string appStoreAppID = "";
	public string googleAppID = "";

	public string appStoreURL = "";
	public string googlePlayURL = "";

	private bool isMusicActive = true;
	private bool isHapticActive = true;

	public GameObject exitButton;

	private float timeScale;

	//private FB_Init fbInit;

	private static readonly string RESTORE_PURCHASES = "RESTORE PURCHASES";
	private static readonly string ON_TEXT = "ON";
	private static readonly string OFF_TEXT = "OFF";

	private void OnEnable()
	{
		if (PrefManager.GetSound == 0)
		{
			AudioListener.volume = 0;
			soundButton.GetComponent<Image>().sprite = soundOffSprite;
			isMusicActive = false;
		}
		else
		{
			AudioListener.volume = 1;
			soundButton.GetComponent<Image>().sprite = soundOnSprite;
			isMusicActive = true;
		}

		if (PrefManager.GetMusic == 0)
		{
			musicButton.GetComponent<Image>().sprite = musicOffSprite;
		}
		else
		{
			musicButton.GetComponent<Image>().sprite = musicOnSprite;
		}

		if (PrefManager.GetVibration == 0)
		{
			vibrateButton.GetComponent<Image>().sprite = vibrateOffSprite;
			MMVibrationManager.SetHapticsActive(false);
			isHapticActive = false;
		}
		else
		{
			vibrateButton.GetComponent<Image>().sprite = vibrateOnSprite;
			isHapticActive = true;
			MMVibrationManager.SetHapticsActive(true);
		}

		restoreButtonText.text = RESTORE_PURCHASES;

		settingBackGround.onClick.AddListener(() =>
		{
			Time.timeScale = timeScale;
			//GameManager.instance.ActiveStatus = lastStatus;
			settingMenuPanel.SetActive(false);
		});

		restoreButtonRect.gameObject.SetActive(false);

	}

	public void UpdatePanelInfo()
	{
		if (PrefManager.GetSound == 0)
		{
			soundButton.GetComponent<Image>().sprite = soundOffSprite;
			soundText.text = OFF_TEXT;
			isMusicActive = false;
		}
		else
		{
			soundButton.GetComponent<Image>().sprite = soundOnSprite;
			soundText.text = ON_TEXT;
			isMusicActive = true;
		}

		if (PrefManager.GetVibration == 0)
		{
			vibrateButton.GetComponent<Image>().sprite = vibrateOffSprite;
			vibrationText.text = OFF_TEXT;
			MMVibrationManager.SetHapticsActive(false);
			isHapticActive = false;
		}
		else
		{
			vibrateButton.GetComponent<Image>().sprite = vibrateOnSprite;
			isHapticActive = true;
			vibrationText.text = ON_TEXT;
			MMVibrationManager.SetHapticsActive(true);
		}

		if (PrefManager.GetMusic == 0)
		{
			musicButton.GetComponent<Image>().sprite = musicOffSprite;
			musicText.text = OFF_TEXT;
		}
		else
		{
			musicButton.GetComponent<Image>().sprite = musicOnSprite;
			musicText.text = ON_TEXT;
		}

		restoreButtonText.text = RESTORE_PURCHASES;
	}

	private void Start()
	{
		//fbInit = FB_Init.instance;
	}

	public void ActivateSettingPanel()
	{
		timeScale = Time.timeScale;
		Time.timeScale = 0;
		settingPanel.SetActive(true);

		UpdatePanelInfo();

		//lastStatus = GameManager.instance.ActiveStatus;

		//GameManager.instance.ActiveStatus = GameStatus.SettingPanel;
	}

	#region SettingMenuPanelButtons

	public void VibrateButton()
	{

		if (isHapticActive)
		{
			vibrateButton.GetComponent<Image>().sprite = vibrateOffSprite;
			vibrationText.text = OFF_TEXT;
			isHapticActive = !isHapticActive;
			MMVibrationManager.SetHapticsActive(false);
			PrefManager.SetVibration(0);
			//fbInit.ButtonEvent(EventInfoType.vibration_button_off);
		}
		else
		{
			vibrateButton.GetComponent<Image>().sprite = vibrateOnSprite;
			vibrationText.text =ON_TEXT;
			isHapticActive = !isHapticActive;
			MMVibrationManager.SetHapticsActive(true);
			PrefManager.SetVibration(1);
			//fbInit.ButtonEvent(EventInfoType.vibration_button_on);
		}
	}

	public void RateButton()
	{

#if UNITY_ANDROID
			Application.OpenURL(googlePlayURL);
			//	Application.OpenURL(RemoteManager.instance.RateUsLink_ANDROID);
#elif UNITY_IOS
		Application.OpenURL(appStoreURL);
		//Application.OpenURL(RemoteManager.instance.RateUsLink_IOS);
#endif
		#region event
		//fbInit.ButtonEvent(EventInfoType.rate_us_button);
		#endregion even
	}

	public void SoundButton()
	{
		if (isMusicActive)
		{
			soundButton.GetComponent<Image>().sprite = soundOffSprite;
			soundText.text = OFF_TEXT;
			isMusicActive = !isMusicActive;
			PrefManager.SetSound(0);

			#region event
			//fbInit.ButtonEvent(EventInfoType.sound_button_off);
			#endregion

		}
		else
		{
			soundButton.GetComponent<Image>().sprite = soundOnSprite;
			soundText.text = ON_TEXT;
			isMusicActive = !isMusicActive;
			PrefManager.SetSound(1);
			#region event
			//fbInit.ButtonEvent(EventInfoType.sound_button_on);
			#endregion
		}
	}
	public void MusicButton()
	{
		if (PrefManager.GetMusic == 0)
		{
			musicButton.GetComponent<Image>().sprite = musicOnSprite;
			musicText.text = ON_TEXT;
			//BGMusicController.instance.ControlBGMusic(true);
			PrefManager.SetMusic(1);
			#region event
			//fbInit.ButtonEvent(EventInfoType.music_button_on);
			#endregion
		}
		else
		{
			musicButton.GetComponent<Image>().sprite = musicOffSprite;
			musicText.text = OFF_TEXT;
			//BGMusicController.instance.ControlBGMusic(false);
			PrefManager.SetMusic(0);
			#region event
			//fbInit.ButtonEvent(EventInfoType.music_button_off);
			#endregion
		}
	}

	public void RestartButton()
	{
		Time.timeScale = 1;
		PrefManager.SetByPass(true);
		SceneManager.LoadScene(UpperUtil.MAIN_SCENE);
	}

	public void RestorePurchaseButton()
	{
		//IAPManager.instance.RestorePurchases();
	}

	public void ClosePopUpButton()
	{
		Time.timeScale = timeScale;
		//GameManager.instance.ActiveStatus = lastStatus;
		settingMenuPanel.SetActive(false);
	}
	public void ExitButton()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(UpperUtil.MAIN_SCENE);
	}

	#endregion


}
