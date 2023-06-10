using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Upperpik
{

	public static class ComponentExt
	{

		public static bool HasBeenDestroyed(this Component self)
		{
			return self == null || self.gameObject == null;
		}

		public static T GetOrAddComponent<T>(this Component self) where T : Component
		{
			return self.GetComponent<T>() ?? self.gameObject.AddComponent<T>();
		}

		public static T AddComponent<T>(this Component self) where T : Component
		{
			return self.gameObject.AddComponent<T>();
		}

		public static GameObject[] GetAllChildren(this Component self, bool includeInactive = false)
		{
			return self
				.GetComponentsInChildren<Transform>(includeInactive)
				.Where(c => c != self.transform)
				.Select(c => c.gameObject)
				.ToArray()
			;
		}
		public static Transform[] GetChildrenTransforms(this Component self, bool includeInactive = false)
		{
			return self
				.GetComponentsInChildren<Transform>(includeInactive)
				.Where(c => c != self.transform)
				.Select(c => c.transform)
				.ToArray()
			;
		}
		public static GameObject[] GetChildren(this Component self)
		{
			GameObject[] children = new GameObject[self.transform.childCount];
			for (int i = 0; i < self.transform.childCount; i++)
			{
				children[i] = self.transform.GetChild(i).gameObject;
			}
			return children;
			//return self
			//	.GetComponentsInChildren<Transform>(includeInactive)
			//	.Where(c => c != self.transform)
			//	.Select(c => c.gameObject)
			//	.ToArray()
			//;
		}

		public static T[] GetComponentsInChildrenWithoutSelf<T>(this Component self) where T : Component
		{
			return self.GetComponentsInChildren<T>()
				.Where(c => self.gameObject != c.gameObject)
				.ToArray()
			;
		}

		public static void RemoveComponent<T>(this Component self) where T : Component
		{
			GameObject.Destroy(self.GetComponent<T>());
		}

		public static void RemoveComponents<T>(this Component self) where T : Component
		{
			foreach (Component component in self.GetComponents<T>())
			{
				GameObject.Destroy(component);
			}
		}

		public static void RemoveComponentImmediate<T>(this Component self) where T : Component
		{
			GameObject.DestroyImmediate(self.GetComponent<T>());
		}

		public static void RemoveComponentsImmediate<T>(this Component self) where T : Component
		{
			foreach (Component component in self.GetComponents<T>())
			{
				GameObject.DestroyImmediate(component);
			}
		}

		public static bool HasComponent<T>(this Component self) where T : Component
		{
			return self.GetComponent<T>() != null;
		}

		public static T CopyComponent<T>(T original, GameObject destination) where T : Component
		{
			System.Type type = original.GetType();
			var dst = destination.GetComponent(type) as T;
			if (!dst) dst = destination.AddComponent(type) as T;
			var fields = type.GetFields();

			foreach (var field in fields)
			{
				if (field.IsStatic) continue;

				field.SetValue(dst, field.GetValue(original));
			}
			var props = type.GetProperties();

			foreach (var prop in props)
			{
				if (!prop.CanWrite || !prop.CanWrite || prop.Name == "name" || prop.Name == "hideFlags")
				{
					continue;
				}
				prop.SetValue(dst, prop.GetValue(original, null), null);
			}
			return dst as T;
		}

		public static TYPE[] GetAllComponents<TYPE>(this GameObject gameObject) where TYPE : class
		{
			gameObject = gameObject.transform.root.gameObject;
			if (typeof(TYPE).IsInterface)
			{
				List<TYPE> ret = new List<TYPE>();
				TYPE add;
				foreach (var c in gameObject.GetComponentsInChildren<Component>())
				{
					add = c as TYPE;
					if (add != null) ret.Add(add);
				}
				return ret.ToArray();
			}
			else return gameObject.GetComponentsInChildren<TYPE>();
		}

		public static TYPE GetFirstComponent<TYPE>(this GameObject gameObject) where TYPE : class
		{
			gameObject = gameObject.transform.root.gameObject;
			if (typeof(TYPE).IsInterface)
			{
				foreach (var c in gameObject.GetComponentsInChildren<Component>())
				{
					if (c is TYPE) return c as TYPE;
				}
				return null;
			}
			else return gameObject.GetComponentInChildren<TYPE>();
		}

		public static TYPE GetOrAddComponent<TYPE>(this GameObject gameObject) where TYPE : Component
		{
			TYPE component = gameObject.GetComponent<TYPE>();
			if (component == null) component = gameObject.AddComponent<TYPE>();
			return component;
		}
	}
}