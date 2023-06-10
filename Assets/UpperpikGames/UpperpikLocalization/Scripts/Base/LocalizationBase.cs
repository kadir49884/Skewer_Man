using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upperpik/Localization/Language")]
public class LocalizationBase : ScriptableObject
{
	[Space(15)]
	[SerializeField] private SystemLanguage language;

	public SystemLanguage Language { get => language; }

	[Space(15)]
	public string TOAST_MESSAGE_AD;
	public string HIGH_SCORE;
	public string CLAIM;
	public string FAIL;
	public string YOU_NEED_MORE_DIAMOND;
	public string SWIPE_TO_PLAY;
	public string LVL_TEXT;

	public string RATE;
	public string SOUND;
	public string VIBRATION;
	public string RESTART;
	public string EXIT;
	public string RESUME;
	public string GET;
	public string SHOP;
	public string TAP_AND_HOLD;
	public string GET_FREE_TEXT;
	public string UNLOCK_RANDOM_TEXT;
	public string SUCCESS_TEXT;
	public string YOU_FAILED_TEXT;
	public string RETRY_TEXT;
	public string SECOND_CHANCE_TEXT;
	public string OPEN_ALL_TEXT;
	public string CONTINUE_TEXT;
	public string ON_TEXT;
	public string OFF_TEXT;
	public string SHOWROOM_CLAIM_TEXT;
	public string RESTORE_PURCHASE_TEXT;
	public string NO_AD_PURCHASED_SUCCESSFULLY_TEXT;
	public string NO_AD_PURCHASE_FAILED_TEXT;
	public string SUCCESSFULLY_RESTORE_TEXT;
	public string ALREADY_RESTORED_TEXT;
	public string FAILED_RESTORE_TEXT;
	public string MUSIC_TEXT;

//	[ListDrawerSettings(ShowIndexLabels = false, OnBeginListElementGUI = "EnumName", OnEndListElementGUI = "End")]
//	[SerializeField]
//	public string[] VISUAL_FEEDBACK_TEXTS;

//#if UNITY_EDITOR
//	public void End()
//	{
//		Sirenix.Utilities.Editor.SirenixEditorGUI.EndBox();
//	}
//	public void EnumName(int index)
//	{
//		Sirenix.Utilities.Editor.SirenixEditorGUI.BeginBox(label: ((VisualFeedbackType)index).ToString());
//	}

//#endif

}