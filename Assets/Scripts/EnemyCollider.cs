using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.VersionControl;
using UnityEngine;
using DG.Tweening;

public class EnemyCollider : MonoBehaviour
{

	private Animator anim;
	private GameManager gameManager;
	private List<Rigidbody> childBodys;
	private Vector3 direction;
	private int enemyCount;
	private int spearCount;
	private Rigidbody rb;
	private GameObject playerObject;
	private bool isNearPlayer = false;
	private bool isDead = false;
	private bool colliderControl = true;

	void Start()
	{

		anim = GetComponent<Animator>();
		gameManager = GameManager.Instance;
		gameManager.GameStart += GameStarted;
		childBodys = GetComponentsInChildren<Rigidbody>().ToList();
		rb = GetComponent<Rigidbody>();
	}


	private void GameStarted()
	{
		anim.SetBool("Walk", true);
	}

	private void FixedUpdate()
	{
		if (!isDead && gameManager.IsGameStarted)
		{
			rb.velocity = transform.forward;
			if (isNearPlayer)
			{
				transform.LookAt(playerObject.transform);
			}
		}

	}


	public void GoSpearPos(GameObject newObject)
	{
		enemyCount = newObject.GetComponent<SpearTipCollider>().EnemyOnSpearCount;
		spearCount = newObject.GetComponent<SpearTipCollider>().SpearPieceCount;


		if (spearCount - 1 > enemyCount)
		{
			gameObject.SetLayer("EnemyOnSpear", true);
			GetComponent<CapsuleCollider>().enabled = false;
			Destroy(GetComponent<Animator>());

			if (newObject.GetComponent<SpearTipCollider>())
			{
				newObject.GetComponent<SpearTipCollider>().EnemyOnSpearCount++;
			}
			transform.parent = newObject.transform;

			GameObject childObject = transform.GetChild(1).gameObject;

			childObject.GetComponent<SkinnedMeshRenderer>().material.color = new Color(0.7f, 0.7f, 0.7f);
			childObject.GetComponent<SkinnedMeshRenderer>().material.SetColor(UpperUtil.PROP_EMISSION_COLOR, Color.black);


			for (int i = 3; i < childBodys.Count; i++)
			{
				childBodys[i].isKinematic = false;
			}

			for (int i = 0; i < newObject.transform.childCount; i++)
			{
				newObject.transform.GetChild(i).DOLocalMoveZ((i - newObject.transform.childCount) / 2.5f, .2f);
				newObject.transform.GetChild(i).DOLocalMoveX(0, 0.2f);
			}

			foreach (var item in childBodys)
			{
				item.drag = 10;
				item.angularDrag = 5;
			}
		}
		rb.isKinematic = true;

	}

	public void EnemyCrashPointLeft()
	{
		direction = Vector3.left;
		EnemyGoWay();
	}

	public void EnemyCrashPointRight()
	{
		direction = Vector3.right;
		EnemyGoWay();
	}

	public void EnemyGoWay()
	{
		if (colliderControl)
		{
			GameObject childObject = transform.GetChild(1).gameObject;

			GetComponent<CapsuleCollider>().isTrigger = true;
			colliderControl = false;
			gameObject.SetLayer("Ignore", true);
			isDead = true;
			anim.enabled = false;

			childObject.GetComponent<SkinnedMeshRenderer>().material.color = new Color(0.7f, 0.7f, 0.7f);
			childObject.GetComponent<SkinnedMeshRenderer>().material.SetColor(UpperUtil.PROP_EMISSION_COLOR, Color.black);

			childObject.GetComponent<ChangeRenderingMode>().MakeFade();
			childObject.GetComponent<SkinnedMeshRenderer>().material.DOFade(0.1f, 6);

			foreach (var item in childBodys)
			{
				item.isKinematic = false;
				item.velocity = direction * 5 + Vector3.up * 2 + Vector3.forward * 20;
			}

			rb.velocity = direction * 5 + Vector3.up * 2 + Vector3.forward * 20;
			Destroy(gameObject, 3);
		}
	}

	public void LookPlayer(GameObject newObject)
	{
		playerObject = newObject.transform.parent.gameObject;
		isNearPlayer = true;
	}

}
