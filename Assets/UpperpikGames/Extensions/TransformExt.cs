using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Upperpik
{

	public enum CompareType
	{
		And,
		Or
	}

	public enum FaceType
	{
		Up,
		Down,
		Left,
		Right,
		Forward,
		Back
	}

	public static class TransformExt
	{
		public static void SetPos2D(this Transform trans, Vector3 pos)
		{
			trans.position = new Vector3(pos.x, pos.y, trans.position.z);
		}
		public static void SetPos2D(this Transform trans, float xPos, float yPos)
		{
			trans.position = new Vector3(xPos, yPos, trans.position.z);
		}

		public static void SetLocalPos2D(this Transform trans, float xPos, float yPos)
		{
			trans.localPosition = new Vector3(xPos, yPos, trans.localPosition.z);
		}

		public static void SetLocalPos2D(this Transform trans, Vector2 pos)
		{
			trans.localPosition = new Vector3(pos.x, pos.y, trans.localPosition.z);
		}

		public static void SetLocalPosZ(this Transform trans, float posZ)
		{
			trans.localPosition = new Vector3(trans.localPosition.x, trans.localPosition.y, posZ);
		}

		public static void SetLocalPosY(this Transform trans, float posY)
		{
			trans.localPosition = new Vector3(trans.localPosition.x, posY, trans.localPosition.z);
		}

		public static void SetLocalPosX(this Transform trans, float posX)
		{
			trans.localPosition = new Vector3(posX, trans.localPosition.y, trans.localPosition.z);
		}

		public static void SetPosX(this Transform trans, float xPos)
		{
			trans.position = new Vector3(xPos, trans.position.y, trans.position.z);
		}
		public static void SetPosY(this Transform trans, float yPos)
		{
			trans.position = new Vector3(trans.position.x, yPos, trans.position.z);
		}

		/// <summary>
		/// Set world angle
		/// </summary>
		/// <param name="trans"></param>
		/// <param name="angle"></param>
		public static void SetAngleZ(this Transform trans, float angle)
		{
			trans.eulerAngles = new Vector3(trans.eulerAngles.x, trans.eulerAngles.y, angle);
		}

		public static void SetAngleY(this Transform trans, float angle)
		{
			trans.eulerAngles = new Vector3(trans.eulerAngles.x, angle, trans.eulerAngles.z);
		}

		public static void SetAngleX(this Transform trans, float angle)
		{
			trans.eulerAngles = new Vector3(angle, trans.eulerAngles.x, trans.eulerAngles.z);
		}

		public static void SetScaleOneValue(this Transform trans, float value)
		{
			trans.localScale = new Vector3(value, value, trans.localScale.z);
		}
		public static void SetLocalAngleZ(this Transform trans, float angle)
		{
			trans.localEulerAngles = new Vector3(trans.localEulerAngles.x, trans.localEulerAngles.y, angle);
		}

		public static void SetLocalScale2D(this Transform trans, Vector2 scale)
		{
			trans.localScale = new Vector3(scale.x, scale.y, trans.localEulerAngles.z);
		}

		public static void SetLocalScale2D(this Transform trans, float xScale, float yScale)
		{
			trans.localScale = new Vector3(xScale, yScale, trans.localEulerAngles.z);
		}


		//Breadth-first search
		public static Transform FindDeepChild(this Transform aParent, string aName)
		{
			var result = aParent.Find(aName);
			if (result != null)
				return result;
			foreach (Transform child in aParent)
			{
				result = child.FindDeepChild(aName);
				if (result != null)
					return result;
			}
			return null;
		}

		public static void SetActiveChildren(this Transform aParent, bool isActive)
		{
			for (int i = 0; i < aParent.childCount; i++)
			{
				aParent.GetChild(i).gameObject.SetActive(isActive);
			}
		}
		public static void SetActiveChildren(this Transform aParent, bool isActive, int from, int to)
		{
			for (int i = from; i < to; i++)
			{
				aParent.GetChild(i).gameObject.SetActive(isActive);
			}
			for (int j = to; j < aParent.transform.childCount; j++)
			{
				aParent.GetChild(j).gameObject.SetActive(!isActive);
			}
		}
		public static void LookAtX(this Transform aParent, Transform targetTRA, float deviationValue)
		{
			Vector3 lookPos = targetTRA.position - aParent.position;
			Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
			float eulerY = lookRot.eulerAngles.y;
			Quaternion rotation = Quaternion.Euler(0, eulerY, 0);
			aParent.rotation = rotation;
		}
		public static void LookAtY(this Transform aParent, Transform targetTRA, float lerpSpeed, bool setOthersToZero = false)
		{
			var lookPos = targetTRA.position - aParent.position;
			lookPos.y = 0;
			var rotation = Quaternion.LookRotation(lookPos);
			aParent.rotation = Quaternion.Slerp(aParent.rotation, rotation, lerpSpeed);
			aParent.eulerAngles = setOthersToZero ? new Vector3(0, aParent.eulerAngles.y, 0) : aParent.eulerAngles;
		}
		public static void LookAtZ(this Transform aParent, Transform targetTRA, float deviationValue, float time)
		{
			Vector3 difference = targetTRA.position - aParent.position;
			float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
			Quaternion temp = Quaternion.Euler(0.0f, 0.0f, rotationZ + deviationValue);
			aParent.transform.rotation = Quaternion.Slerp(temp, aParent.transform.rotation, time);
		}

		public static void LookAtZ(this Transform aParent, Transform targetTRA, float deviationValue, bool isLerp, float time)
		{
			Vector3 difference = targetTRA.position - aParent.position;
			float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
			Quaternion temp = Quaternion.Euler(0.0f, 0.0f, rotationZ + deviationValue);
			aParent.rotation = Quaternion.Slerp(temp, aParent.transform.rotation, time);
		}

		public static void AddChild(this Transform aParent, Transform child)
		{
			child.SetParent(aParent);
		}
		public static void SetParentAndResetTransform(this Transform myTransform, Transform parent)
		{
			myTransform.SetParent(parent);
			myTransform.Reset();
		}
		public static void Reset(this Transform aParent)
		{
			aParent.localPosition = Vector3.zero;
			aParent.localEulerAngles = Vector3.zero;
			aParent.localScale = Vector3.one;
		}

		public static bool IsLastChild(this Transform aParent)
		{
			if (aParent.parent == null)
				return false;

			int childCount = aParent.parent.childCount;
			int siblingIndex = aParent.GetSiblingIndex();
			return childCount - 1 == siblingIndex;
		}

		public static Transform GetFirstChild(this Transform aParent)
		{
			return aParent.GetChild(0);
		}

		public static Transform GetLastChild(this Transform aParent)
		{
			return aParent.GetChild(aParent.childCount - 1);
		}

		public static Transform GetRandomChild(this Transform aParent)
		{
			return aParent.GetChild(Random.Range(0, aParent.childCount));
		}

		public static Vector3 GetFacePosition(this Transform aParent, FaceType faceType)
		{

			Vector3 halfScale = aParent.transform.localScale / 2;
			Vector3 pos = Vector3.zero;
			switch (faceType)
			{
				case FaceType.Up:
					pos = aParent.transform.position + halfScale.y * Vector3.up;
					break;
				case FaceType.Down:
					pos = aParent.transform.position + halfScale.y * Vector3.down;
					break;
				case FaceType.Left:
					pos = aParent.transform.position + halfScale.x * Vector3.left;
					break;
				case FaceType.Right:
					pos = aParent.transform.position + halfScale.x * Vector3.right;
					break;
				case FaceType.Forward:
					pos = aParent.transform.position + halfScale.z * Vector3.forward;
					break;
				case FaceType.Back:
					pos = aParent.transform.position + halfScale.z * Vector3.back;
					break;
				default:
					break;
			}

			return pos;
		}

		public static bool CompareTags(this Transform aParent, CompareType type, params string[] tags)
		{
			bool result = false;

			switch (type)
			{
				case CompareType.And:
					result = true;
					for (int i = 0; i < tags.Length; i++)
					{
						result = result && aParent.CompareTag(tags[i]);
					}
					break;
				case CompareType.Or:
					result = false;
					for (int i = 0; i < tags.Length; i++)
					{
						result = result || aParent.CompareTag(tags[i]);
					}
					break;
				default:
					break;
			}

			return result;
		}

		public static Vector3 GetInspectorAngle(this Transform aParent)
		{
			Vector3 angle = aParent.eulerAngles;
			float x = angle.x;
			float y = angle.y;
			float z = angle.z;

			if (Vector3.Dot(aParent.up, Vector3.up) >= 0f)
			{
				if (angle.x >= 0f && angle.x <= 90f)
				{
					x = angle.x;
				}
				if (angle.x >= 270f && angle.x <= 360f)
				{
					x = angle.x - 360f;
				}
			}
			if (Vector3.Dot(aParent.up, Vector3.up) < 0f)
			{
				if (angle.x >= 0f && angle.x <= 90f)
				{
					x = 180 - angle.x;
				}
				if (angle.x >= 270f && angle.x <= 360f)
				{
					x = 180 - angle.x;
				}
			}

			if (angle.y > 180)
			{
				y = angle.y - 360f;
			}

			if (angle.z > 180)
			{
				z = angle.z - 360f;
			}

			return new Vector3(Mathf.Round(x), Mathf.Round(y), Mathf.Round(z));
		}

		public static Vector3 GetCenter(this Transform aParent)
		{
			var rends = aParent.GetComponentsInChildren<Renderer>();
			if (rends.Length == 0)
				return aParent.position;
			var b = rends[0].bounds;
			for (int i = 1; i < rends.Length; i++)
			{
				b.Encapsulate(rends[i].bounds);
			}
			return b.center;
		}

		public static void IsTrigger(this Transform aParent, bool isTrigger)
		{
			aParent.GetComponent<Collider>().isTrigger = isTrigger;
		}

		public static void IsTriggerAll(this Transform aParent, bool isTrigger)
		{
			foreach (var item in aParent.GetComponentsInChildren<Collider>())
			{
				item.isTrigger = isTrigger;
			}
		}

		public static Vector3 GetMiddlePoint(this Transform first, Transform second) => (first.position + second.position) / 2f;

		public static void Set3DObjectToUI(this Transform objectTR, Camera uıCamera, Transform canvasTransform, Vector3 scale)
		{
			Camera _mainCamera = Camera.main;

			Vector3 screenPos = _mainCamera.WorldToScreenPoint(objectTR.position);
			screenPos.z = _mainCamera.nearClipPlane;
			Vector3 pos;
			RectTransformUtility.ScreenPointToWorldPointInRectangle(
			canvasTransform as RectTransform, screenPos,
			uıCamera,
			out pos);
			objectTR.SetParent(canvasTransform);
			objectTR.gameObject.SetLayer("UI");

			objectTR.position = pos;
			objectTR.localScale = scale;
		}

	}
}