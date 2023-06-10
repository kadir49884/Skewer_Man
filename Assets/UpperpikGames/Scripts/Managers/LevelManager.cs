using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Upperpik.Managers
{
	[CreateAssetMenu(menuName = "Upperpik/Managers/LevelManager")]
	public class LevelManager : ScriptableBase
	{
		#region UNITY_EDIOR
#if UNITY_EDITOR
		[PropertySpace(30)]
		[Button(ButtonSizes.Large, Style = ButtonStyle.CompactBox)]
		private void SetPlayerPrefs(int levelIndex = 1)
		{
			PrefManager.SetLevel(levelIndex);
		}
		[PropertySpace(30)]
		[Button(ButtonSizes.Large, Style = ButtonStyle.CompactBox)]
		private void SetMoney(int money = 99000)
		{
			PrefManager.SetMoney(money);
		}
#endif
		#endregion

		[ReadOnly] public LevelScriptable activeLevel;
		public GameObject level;

		private void SetLevel()
		{
			activeLevel = GetLevel();

			InitializeLevel();
		}

		private void InitializeLevel()
		{
			// TODO : Set active level properties
			if (activeLevel != null && activeLevel.levelPrefab != null)
				level = Instantiate(activeLevel.levelPrefab);
		}

		private LevelScriptable GetLevel()
		{
			int levelIndex = PrefManager.GetLevel;

			LevelScriptable level = Resources.Load(UpperUtil.LEVELS_PATH + levelIndex) as LevelScriptable;

			if (level == null)
			{
				PrefManager.SetLevel(1);
				levelIndex = PrefManager.GetLevel;
				level = Resources.Load(UpperUtil.LEVELS_PATH + levelIndex) as LevelScriptable;
			}
			return level;
		}

		public void Initialize()
		{
			var trashObjects = FindObjectsOfType<LevelController>().ToList();

			if (trashObjects.Count > 0)
				trashObjects.ForEach(trash => Destroy(trash.gameObject));
			
			SetLevel();
		}
	}
}