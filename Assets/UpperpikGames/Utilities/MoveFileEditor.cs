#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Upperpik;

public class MoveFileEditor : EditorWindow
{
	private int index;

	static string[] options = new string[]
	{
		 "Scripts", "Textures", "Materials","Models","Prefabs","Scenes","Sounds","ExternalTools","Resources","Animations",
		Path.Combine("Resources", "Levels"),Path.Combine("Materials", "PhysicMaterials")
	};


	[MenuItem("Upperpik/MoveFile")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(MoveFileEditor), utility: false, title: "Move File");
	}

	[MenuItem("Upperpik/Start New Project")]
	public static void StartNewProject()
	{
		CreateNecessaryDirectory();

		SetPlayerSettings();

		PrepareScene();
	}

	private static void PrepareScene()
	{
		if (!FindObjectOfType<GameManager>())
			new GameObject("GameManager").AddComponent<GameManager>();


		Camera UICamera;

		if (!GameObject.Find("UICamera"))
			UICamera = new GameObject("UICamera").AddComponent<Camera>();
		else
			UICamera = GameObject.Find("UICamera").GetComponent<Camera>();

		if (UICamera.GetComponent<AudioListener>())
			DestroyImmediate(UICamera.GetComponent<AudioListener>());

		UICamera.orthographic = true;
		UICamera.depth = 1;
		UICamera.clearFlags = CameraClearFlags.Depth;
		UICamera.cullingMask = 5 << 5;


		if (!FindObjectOfType<ObjectManager>())
		{
			ObjectManager objectManager = new GameObject("ObjectManager").AddComponent<ObjectManager>();
			objectManager.OrthoCamera = UICamera;
		}

		Camera.main.LayerCullingToggle("UI", false);

		Canvas mainCanvas;

		if (!FindObjectOfType<Canvas>())
			mainCanvas = new GameObject("MainCanvas").AddComponent<Canvas>();
		else
			mainCanvas = FindObjectOfType<Canvas>();

		if (mainCanvas.GetComponent<CanvasScaler>() == null)
		{
			CanvasScaler canvasScaler = mainCanvas.AddComponent<CanvasScaler>();

			canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			canvasScaler.referenceResolution = new Vector2(1080, 1920);
		}

		if (!mainCanvas.GetComponent<GraphicRaycaster>())
			mainCanvas.AddComponent<GraphicRaycaster>();

		if (!mainCanvas.GetComponent<CanvasManager>())
			mainCanvas.AddComponent<CanvasManager>();

		mainCanvas.renderMode = RenderMode.ScreenSpaceCamera;
		mainCanvas.worldCamera = UICamera;

		if (!FindObjectOfType<EventSystem>())
		{
			EventSystem eventSystem = new GameObject("EventSystem").AddComponent<EventSystem>();
			eventSystem.AddComponent<StandaloneInputModule>();
		}

		if (!Camera.main.GetComponent<CameraMovement>())
			Camera.main.AddComponent<CameraMovement>();
	}

	private static void CreateNecessaryDirectory()
	{
		string path = Application.dataPath;
		options.ForEach(item =>
		{
			if (!Directory.Exists(Path.Combine(path, item)))
				Directory.CreateDirectory(Path.Combine(path, item));
		});
		AssetDatabase.Refresh();
	}
	private static void SetPlayerSettings()
	{
		PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.Android, ApiCompatibilityLevel.NET_4_6);
		PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.iOS, ApiCompatibilityLevel.NET_4_6);
		PlayerSettings.companyName = UpperUtil.UPPERPIK_GAMES;
		PlayerSettings.defaultInterfaceOrientation = UIOrientation.Portrait;
	}

	void OnGUI()
	{
		GUIStyle gUIStyle = new GUIStyle();

		gUIStyle.fontStyle = FontStyle.Bold;
		gUIStyle.fontSize = 25;
		gUIStyle.normal.textColor = Color.red;
		gUIStyle.alignment = TextAnchor.MiddleCenter;
		gUIStyle.padding = new RectOffset() { bottom = 20, top = 10 };

		GUILayout.Label("Move File", gUIStyle);


		index = EditorGUILayout.Popup("File Type : ", index, options);

		if (GUILayout.Button("Move"))
			MoveFileFunc(options[index]);
		else if (GUILayout.Button("Move All"))
		{
			foreach (string item in options)
			{
				MoveFileFunc(item);
			}
		}
	}

	public static void MoveFileFunc(string fileType)
	{
		List<string> fileExtensions = new List<string>();
		CreateNecessaryDirectory();
		switch (fileType)
		{
			case "Scripts":
				fileExtensions.Add("*.cs");
				break;
			case "Textures":
				fileExtensions.Add("*.png");
				fileExtensions.Add("*.jpeg");
				fileExtensions.Add("*.jpg");
				break;
			case "Materials":
				fileExtensions.Add("*.mat");
				break;
			case "Models":
				fileExtensions.Add("*.obj");
				fileExtensions.Add("*.fbx");
				fileExtensions.Add("*.mesh");
				break;
			case "Prefabs":
				fileExtensions.Add("*.prefab");
				break;
			default:
				break;
		}
		string path = Application.dataPath;

		string[] filePaths = null;

		fileExtensions.ForEach(fileExtension =>
		{
			filePaths = Directory.GetFiles(path + "/", fileExtension);

			foreach (string item in filePaths)
			{
				string st = Path.GetFileName(item);
				FileUtil.MoveFileOrDirectory(item, Path.Combine(Path.Combine(path, fileType.ToString()), st));
				FileUtil.MoveFileOrDirectory(item + ".meta", Path.Combine(Path.Combine(path, fileType.ToString()), st + ".meta"));
			}
		});

		if (filePaths != null && filePaths.Length > 0)
		{
			Debug.Log(filePaths.Length + " files moved to selected directory!");
			AssetDatabase.Refresh();
		}
	}

}
#endif