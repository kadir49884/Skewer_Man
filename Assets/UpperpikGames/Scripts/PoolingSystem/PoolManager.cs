using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upperpik;
using System.Linq;
using Sirenix.OdinInspector;

public enum PoolType
{
	ExamplePoolObje
}

[System.Serializable]
public class Pool
{
	public PoolType type;
	[AssetsOnly] public GameObject prefab;
	public int size;
}

public class PoolManager : Singleton<PoolManager>
{
	[ShowInInspector, ReadOnly] public Dictionary<string, Queue<GameObject>> poolDictionary;
	[SerializeField, ReadOnly] private List<Transform> poolParents = new List<Transform>();

	public List<Pool> pools;


	private void Start()
	{
		// Create Pool Parents
		GameObject poolParent;

		for (int i = 0; i < pools.Count; i++)
		{
			poolParent = new GameObject();
			poolParent.SetParent(transform);
			poolParent.name = pools[i].type.ToString();
			poolParents.Add(poolParent.transform);
		}

		poolDictionary = new Dictionary<string, Queue<GameObject>>();

		// Create Pool Size
		for (int i = 0; i < pools.Count; i++)
		{
			Queue<GameObject> objectPool = new Queue<GameObject>();

			for (int j = 0; j < pools[i].size; j++)
			{
				GameObject obj = Instantiate(pools[i].prefab, parent: poolParents[i]);
				obj.SetActive(false);
				objectPool.Enqueue(obj);
			}

			poolDictionary.Add(pools[i].type.ToString(), objectPool);
		}

	}

	public GameObject SpawnFromPool(PoolType type, Vector3 position = default, Transform parent = null)
	{
		string tag = type.ToString();

		GameObject objectSpawn;

		if (!poolDictionary.ContainsKey(tag))
		{
			Debug.LogError("Pool with tag " + tag + "doesnt exist");
			return null;
		}

		if (poolDictionary[tag].Count > 0)
		{
			objectSpawn = poolDictionary[tag].Dequeue();
		}
		else
		{
			int poolIndex = poolDictionary.IndexOf(tag);
			pools[poolIndex].size++;
			objectSpawn = Instantiate(pools[poolIndex].prefab);
			//Debug.Log("Pool size :" + pools[poolIndex].size + " : " + poolDictionary[tag].Count);
		}

		objectSpawn.SetActive(true);
		objectSpawn.transform.position = position;
		//if (rotation != default(Quaternion))
		//{
		//	Debug.Log("Def değil");
		//	objectSpawn.transform.rotation = rotation;
		//}

		objectSpawn.SetParent(parent);

		IPooledObject pooled = objectSpawn.GetComponent<IPooledObject>();
		if (pooled != null)
			pooled.OnObjectSpawn();

		objectSpawn.name = type + " :" + objectSpawn.GetInstanceID();
		return objectSpawn;
	}

	public void ReturnPool(GameObject poolable, PoolType type)
	{
		string tag = type.ToString();
		IPooledObject pooled = poolable.GetComponent<IPooledObject>();

		if (pooled != null)
			pooled.OnObjectClose();

		poolable.SetParent(poolParents.Find(a => a.name == type.ToString()));


		if (!poolDictionary[tag].Contains(poolable))
			poolDictionary[tag].Enqueue(poolable);
		else
			Log.ErrorMessage("Pool Contains :" + poolable.name, Colors.red);
	}
}
