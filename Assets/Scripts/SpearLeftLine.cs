using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearLeftLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<EnemyCollider>()?.EnemyCrashPointLeft();
    }
}
