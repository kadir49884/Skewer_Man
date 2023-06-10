using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearOnRoad : MonoBehaviour
{
    private void Start()
    {
        transform.DOLocalRotate(Vector3.up * 20, .2f).SetRelative().SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear).SetDelay(Random.Range(0f, .3f));
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<SpearTipCollider>()?.GetSpear(gameObject);
        
    }

    

}
