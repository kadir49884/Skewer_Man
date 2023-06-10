using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Upperpik;
using Upperpik.Managers;

public class GameManager : Singleton<GameManager>
{
	public bool IsGameFinish { get; set; }
	public bool IsGameStarted { get; set; }

	public Action GameStart { get; set; }
	public Action GameWin { get; set; }
	public Action GameFail { get; set; }

	public bool ExecuteGame { get => IsGameStarted && !IsGameFinish; }

	#region ScriptableManagers

	[SerializeField] private ScriptableBase[] managers;
	public AudioManager AudioManager { get; private set; }
	public ColorManager ColorManager { get; private set; }
	public DataManager DataManager { get; private set; }
	public LevelManager LevelManager { get; private set; }
	public ParticleManager ParticleManager { get; private set; }
	public PrefabManager PrefabManager { get; private set; }
	public SpriteManager SpriteManager { get; private set; }
	public SystemControlManager SystemControlManager { get; private set; }

	#endregion

	private void Awake()
	{
		SetManagers();

		LevelManager.Initialize();      // Loading level 

		if (DataManager != null)
			DataManager.Initialize();       //Initializing DataManager

		GameStart += Initialize;
		GameWin += Game_Win;
		GameFail += Game_Fail;
	}

	private void SetManagers()
	{
		AudioManager = (AudioManager)managers.Find(manager => manager.name.Contains("AudioManager"));
		ColorManager = (ColorManager)managers.Find(manager => manager.name.Contains("ColorManager"));
		DataManager = (DataManager)managers.Find(manager => manager.name.Contains("DataManager"));
		LevelManager = (LevelManager)managers.Find(manager => manager.name.Contains("LevelManager"));
		ParticleManager = (ParticleManager)managers.Find(manager => manager.name.Contains("ParticleManager"));
		PrefabManager = (PrefabManager)managers.Find(manager => manager.name.Contains("PrefabManager"));
		SpriteManager = (SpriteManager)managers.Find(manager => manager.name.Contains("SpriteManager"));
		SystemControlManager = (SystemControlManager)managers.Find(manager => manager.name.Contains("SystemControlManager"));

	}

	public void Initialize()
	{
		IsGameStarted = true;
		//FB_Init.instance.Start_level_Event();
	}

	private void Game_Win()
	{
		IsGameFinish = true;
		//FB_Init.instance.Completed_level_Event();
	}
	private void Game_Fail()
	{
		IsGameFinish = true;
		//FB_Init.instance.Fail_level_Event();
	}

	public void NextLevel()
	{
		PrefManager.SetByPass(true);
		PrefManager.IncrementLevel();
		SceneManager.LoadScene(UpperUtil.MAIN_SCENE);
	}
	public void PreviousLevel()
	{
		PrefManager.SetByPass(true);
		PrefManager.DecrementLevel();
		SceneManager.LoadScene(UpperUtil.MAIN_SCENE);
	}

	public void RestartLevel() => SceneManager.LoadScene(UpperUtil.MAIN_SCENE);

#if UNITY_EDITOR
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
			RestartLevel();

		if (Input.GetKeyDown(KeyCode.N))
			NextLevel();

		if (Input.GetKeyDown(KeyCode.B))
			PreviousLevel();
	}
#endif

}
