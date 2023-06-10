using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<EnemyCollider>()?.LookPlayer(gameObject);
    }
}
