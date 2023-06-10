using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearRightLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<EnemyCollider>()?.EnemyCrashPointRight();
    }
}
