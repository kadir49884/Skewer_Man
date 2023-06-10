using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UpperUtil : MonoBehaviour
{
	#region PrefKeys
	public static string PKEY_BYPASS = "Bypass";
	public static string PKEY_LEVEL = "Level";
	public static string PKEY_MONEY = "Money";
	public static string PKEY_VIBRATION = "Vibration";
	public static string PKEY_SOUND = "Sound";
	public static string PKEY_MUSIC = "Music";
	public static string UPPERPIK_GAMES = "Upperpik";
	#endregion PrefKeys

	#region LevelKeys
	public static string LEVEL = "Level";
	public static string LEVELS = "Levels";
	public static string LEVELS_PATH = Path.Combine("Levels", "Level");
	public static string MAIN_SCENE = "Main";
	public static string PLAYER_POINT = "PlayerPoint";
	#endregion LevelKeys

	#region UIKeys
	public static string UI_OFF_TEXT = "Off";
	public static string UI_ON_TEXT = "On";
	public static string UI_RESTORE_PURCHASE_TEXT = "Restore Purchases";
	#endregion UIKeys

	#region AnimationKeys
	public static string ANIM_RUN = "Run";
	public static string ANIM_IDLE = "Idle";
	#endregion AnimationKeys

	#region TagKeys
	public static string TAG_UNTAGGED = "Untagged";
	public static string TAG_PLAYER = "Player";
	public static string TAG_FINISH = "Finish";
	public static string TAG_RESPAWN = "Respawn";
	public static string TAG_EDITOR_ONLY = "EditorOnly";
	public static string TAG_MAIN_CAMERA = "MainCamera";
	public static string TAG_GAME_CONTROLLER = "GameController";
	#endregion TagKeys

	#region LayerKeys
	public static string LAYER_DEFAULT = "Default";
	public static string LAYER_TRANSPARENT_FX = "TransparentFX";
	public static string LAYER_IGNORE_RAYCAST = "Ignore Raycast";
	public static string LAYER_WATER = "Water";
	public static string LAYER_UI = "UI";
	#endregion LayerKeys

	#region JSON
	public static string SAVED_JSONS = "SavedJson";
	public static string EXT_JSON = ".json";
	#endregion JSON

	public static string EDITOR = "Editor";
	public static string DEFAULT = "Default";

	#region ShaderProperties
	public static string PROP_EMISSION_COLOR = "_EmissionColor";
	public static string PROP_EMISSION_TEXTURE = "_EmissionMap";
	public static string PROP_COLOR = "_Color";
	public static string PROP_ALBEDO = "_MainTex";
	public static string PROP_SMOOTHNESS = "_Glossiness";
	public static string PROP_METALIC = "_Metalic";
	public static string PROP_ALPHA_CUTOFF = "_Cutoff";
	#endregion ShaderProperties
}
