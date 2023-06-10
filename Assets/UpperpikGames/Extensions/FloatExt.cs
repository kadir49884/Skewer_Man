using UnityEngine;

namespace Upperpik
{
	public static class FloatExt
	{
		public static bool SafeEquals(this float self, float obj, float threshold = 0.001f)
		{
			return Mathf.Abs(self - obj) <= threshold;
		}

		public static bool IsValidated(this float self)
		{
			return !float.IsInfinity(self) && !float.IsNaN(self);
		}

		public static float GetValueOrDefault(this float self, float defaultValue = 0)
		{
			if (float.IsInfinity(self) || float.IsNaN(self))
			{
				return defaultValue;
			}
			return self;
		}

		public static void RemapRef(this ref float value, float from1, float to1, float from2, float to2)
		{
			value = (value - from1) / (to1 - from1) * (to2 - from2) + from2;
		}

		public static float Remap(this float value, float from1, float to1, float from2, float to2)
		{
			return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
		}


		public static void Clamp(this ref float value, float min, float max)
		{
			float mn = Mathf.Min(min, max);
			float mx = Mathf.Max(min, max);
			value = Mathf.Clamp(value, mn, mx);
		}

		public static void Abs(this ref float value)
		{
			value = Mathf.Abs(value);
		}

		public static void Abs(this ref int value)
		{
			value = Mathf.Abs(value);
		}

		public static void ClampWithin180Angle(this ref float value, float min, float max)
		{
			value = ConvertToAngle180(value);
			value = Mathf.Clamp(value, min, max);
		}

		private static float ConvertToAngle180(float input)
		{
			while (input > 360)
			{
				input = input - 360;
			}
			while (input < -360)
			{
				input = input + 360;
			}
			if (input > 180)
			{
				input = input - 360;
			}
			if (input < -180)
				input = 360 + input;
			return input;
		}
	}
}