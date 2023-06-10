using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upperpik;

public class DrawManager : Singleton<DrawManager>
{
	[SerializeField, ReadOnly, FoldoutGroup("ReadOnly")] private bool canDraw;
	[SerializeField, ReadOnly, FoldoutGroup("ReadOnly")] private List<Vector3> points = new List<Vector3>();

	[Title("Float")]
	[SerializeField] private float sensitivity;

	[Title("LineRender")]
	[SerializeField] private LineRenderer line;

	[Title("Ray")]
	[SerializeField] private LayerMask layerMask;

	private RaycastHit hit;
	private Ray ray;

	private bool drawStart = false;
	private int edgeIndex;

	private Vector3 currentPosition;
	private Vector3 startPosition;

	private Vector3 localHitPoint;

	private Camera mainCamera;

	public bool CanDraw { get => canDraw; set => canDraw = value; }
    public List<Vector3> Points { get => points; }

    private void Awake()
	{
		mainCamera = Camera.main;
		InitDraw();
	}

	public void InitDraw()
	{
		// line = soldierController.DrawArea; Line renderer verilecek
		CanDraw = true;
		edgeIndex = 0;
	}

	public void Update()
	{
		if (!CanDraw)
			return;

		if (Input.GetMouseButton(0))
		{
			ray = mainCamera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit, 1000, layerMask))
			{
				localHitPoint = hit.point;

				if (!drawStart)
				{
					ResetLine();
					startPosition = localHitPoint;
				}

				currentPosition = localHitPoint;

				if (Vector3.Distance(startPosition, currentPosition) >= sensitivity)
				{
					Points.Add(localHitPoint);

					line.positionCount = Points.Count;
					edgeIndex = Points.Count;

					line.SetPosition(edgeIndex - 1, localHitPoint);
					startPosition = currentPosition;
				}
			}
		}

		if (Input.GetMouseButtonUp(0) && Points.Count > 0)
		{
			drawStart = false;

			ThrowFrisBee();
			ResetLine();
		}
	}

	private void LateUpdate()
	{
		if (!CanDraw)
			return;

		line.material.SetTextureScale("_MainTex", new Vector2(GetLineLenght() / 5f, 0.1f));
	}

	private void ResetLine()
	{
		line.transform.DestroyAllChild();
		Points.Clear();
		line.positionCount = 0;
		edgeIndex = 0;
		drawStart = true;
		DOTween.Kill("DrawFade");
		Color color = line.material.color.SetColorAlpha(1);
		line.material.color = color;
	}

	private void UpdateSoldier()
	{
		if (true) // Şart girilebilir yetersiz nokta olmadıysa yapma 
		{
			ResetLine();
			Log.Message("Yetersiz Nokta", Colors.magenta);
			return;
		}

		line.material.DOFade(0, 1f).SetEase(Ease.Linear).SetId("DrawFade");
	}

	public float GetLineLenght()
	{
		float distance = 0;
		for (int i = 0; i < line.positionCount - 1; i++)
		{
			distance += Vector3.Distance(line.GetPosition(i), line.GetPosition(i + 1));
		}
		return distance;
	}

	public event Action throwFrisbee;
	public void ThrowFrisBee()
    {
		if(throwFrisbee != null)
        {
			throwFrisbee();
        }
    }
	
}
