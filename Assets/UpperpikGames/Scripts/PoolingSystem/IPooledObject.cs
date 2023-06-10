using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upperpik;

public interface IPooledObject
{
	void OnObjectSpawn();
	void OnObjectClose();
}
