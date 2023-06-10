using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpearTipCollider : MonoBehaviour
{
    private int enemyOnSpearCount = 0;
    private int spearPieceCount = 3;

    public int EnemyOnSpearCount { get => enemyOnSpearCount; set => enemyOnSpearCount = value; }
    public int SpearPieceCount { get => spearPieceCount; set => spearPieceCount = value; }

    private GameObject[] spearMiddleObject = new GameObject[2];

    [SerializeField]
    private float length = 0.3f;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<EnemyCollider>()?.GoSpearPos(gameObject);
    }

    public void GetSpear(GameObject newObject)
    {
        spearPieceCount++;
        transform.parent.transform.DOLocalMoveZ(transform.parent.transform.localPosition.z - length, 0.5f);

        spearMiddleObject[0] = transform.parent.parent.GetChild(1).GetChild(0).gameObject;
        spearMiddleObject[1] = transform.parent.parent.GetChild(1).GetChild(1).gameObject;


        spearMiddleObject[0].AddLocalScaleZ(0.2f); 
        spearMiddleObject[1].AddLocalScaleZ(0.2f);
        Destroy(newObject);
    }


    

}
