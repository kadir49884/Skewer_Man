using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Upperpik;

[CreateAssetMenu(menuName = "Upperpik/Managers/DataManager")]
public class DataManager : ScriptableBase
{
	private string dataPath;

	public override void Initialize()
	{
		base.Initialize();
#if UNITY_EDITOR

		string path = Path.Combine(Application.dataPath, "Resources");

		if (!Directory.Exists(path))
			Directory.CreateDirectory(path);
#endif
	}

	public void WriteJson<T>(List<T> newData, bool append = false, bool writeToResources = true)
	{

#if !UNITY_EDITOR
		dataPath = Path.Combine(Application.persistentDataPath, typeof(T).ToString()+".json");
#else
		if (writeToResources)
			dataPath = Path.Combine(Path.Combine(Application.dataPath, "Resources"), typeof(T).ToString() + ".json");
		else
			dataPath = Path.Combine(Application.dataPath, typeof(T).ToString() + ".json");
#endif

		if (!File.Exists(dataPath))
		{
			string json = JsonHelper.ToJson(newData.ToArray(), true);
			File.WriteAllText(dataPath, json);
		}
		else
		{
			if (!append)
			{
				File.Delete(dataPath);
				WriteJson(newData, append, writeToResources);
				return;
			}
			else
			{
				List<T> readedData = ReadJson<T>();
				readedData.AddRange(newData);
				string json = JsonHelper.ToJson(readedData.ToArray(), true);
				File.WriteAllText(dataPath, json);
			}

		}
	}

	public void WriteJson<T>(T data, bool writeToResources = true)
	{

#if !UNITY_EDITOR
		dataPath = Path.Combine(Application.persistentDataPath, typeof(T).ToString()+".json");
#else
		if (writeToResources)
			dataPath = Path.Combine(Path.Combine(Application.dataPath, "Resources"), typeof(T).ToString() + ".json");
		else
			dataPath = Path.Combine(Application.dataPath, typeof(T).ToString() + ".json");
#endif
		List<T> newData = new List<T>();
		newData.Add(data);

		if (File.Exists(dataPath))
		{
			List<T> readedData = ReadJson<T>();
			newData.AddRange(readedData);
		}

		string json = JsonHelper.ToJson(newData.ToArray(), true);
		File.WriteAllText(dataPath, json);
	}

	public List<T> ReadJson<T>(bool readFromResources = true)
	{

#if !UNITY_EDITOR
		dataPath = Path.Combine(Application.persistentDataPath, typeof(T).ToString()+".json");
#else
		if (readFromResources)
			dataPath = Path.Combine(Path.Combine(Application.dataPath, "Resources"), typeof(T).ToString() + ".json");
		else
			dataPath = Path.Combine(Application.dataPath, typeof(T).ToString() + ".json");
#endif
		string json = "";

		if (File.Exists(dataPath))
			json = File.ReadAllText(dataPath);

		if (!string.IsNullOrEmpty(json))
			return JsonHelper.FromJson<T>(json).ToList();
		else
			return null;
	}

	public bool RemoveFromJson<T>(T data, bool readFromResources = true)
	{
#if !UNITY_EDITOR
		dataPath = Path.Combine(Application.persistentDataPath, typeof(T).ToString()+".json");
#else
		if (readFromResources)
			dataPath = Path.Combine(Path.Combine(Application.dataPath, "Resources"), typeof(T).ToString() + ".json");
		else
			dataPath = Path.Combine(Application.dataPath, typeof(T).ToString() + ".json");
#endif
		string json = File.ReadAllText(dataPath);
		List<T> readedData = JsonHelper.FromJson<T>(json).ToList();

		if (readedData == null)
			return false;
		else
			return readedData.Remove(data);
	}
}
