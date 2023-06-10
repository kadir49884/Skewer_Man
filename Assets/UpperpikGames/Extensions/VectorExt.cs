using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Upperpik
{
	public static class VectorExt
	{
		#region Vector2 Ext

		public static Vector2 Abs(this Vector2 me)
		{
			return new Vector2(Mathf.Abs(me.x), Mathf.Abs(me.y));
		}

		public static Vector2 LerpTo(this Vector2 me, Vector2 towards, float t)
		{
			return Vector2.Lerp(me, towards, t);
		}

		public static Vector2 Round(this Vector2 me)
		{
			return new Vector2(Mathf.Round(me.x), Mathf.Round(me.y));
		}

		public static Vector2 Ceil(this Vector2 me)
		{
			return new Vector2(Mathf.Ceil(me.x), Mathf.Ceil(me.y));
		}

		public static Vector2 Floor(this Vector2 me)
		{
			return new Vector2(Mathf.Floor(me.x), Mathf.Floor(me.y));
		}

		public static float DistanceSqr(this UnityEngine.Vector2 me, UnityEngine.Vector2 other)
		{
			return (me - other).sqrMagnitude;
		}

		public static float Distance(this UnityEngine.Vector2 me, UnityEngine.Vector2 other)
		{
			return UnityEngine.Vector2.Distance(me, other);
		}

		public static float Dot(this UnityEngine.Vector2 me, UnityEngine.Vector2 other)
		{
			return UnityEngine.Vector2.Dot(me, other);
		}

		public static float Angle(this UnityEngine.Vector2 me, UnityEngine.Vector2 other)
		{
			return UnityEngine.Vector2.Angle(me, other);
		}

		public static Vector2 Divide(this UnityEngine.Vector2 me, UnityEngine.Vector2 other)
		{
			me.Scale(new UnityEngine.Vector2(1 / other.x, 1 / other.y));
			return me;
		}

		public static Vector2 Multiply(this UnityEngine.Vector2 me, UnityEngine.Vector2 other)
		{
			me.Scale(other);
			return me;
		}

		public static Vector2 Normalized(this UnityEngine.Vector2 me)
		{
			return me.normalized;
		}

		public static float SqrMagnitude(this UnityEngine.Vector2 me)
		{
			return me.sqrMagnitude;
		}

		public static float Magnitude(this UnityEngine.Vector2 me)
		{
			return me.magnitude;
		}

		public static Vector2 Towards(this UnityEngine.Vector2 from, UnityEngine.Vector2 to)
		{
			return to - from;
		}

		public static Vector2 SetX(this Vector2 target, float newX)
		{
			target.x = newX;
			return target;
		}
		public static Vector2 SetY(this Vector2 target, float newY)
		{
			target.y = newY;
			return target;
		}

		public static Vector2 AddX(this Vector2 target, float addX)
		{
			target.x += addX;
			return target;
		}
		public static Vector2 AddY(this Vector2 target, float addY)
		{
			target.y += addY;
			return target;
		}

		public static Vector2 ReturnX(this Vector2 vec, float xValue)
		{
			return new Vector2(xValue, vec.y);
		}

		#endregion Vector2 Ext

		#region Vector2 to Vector3

		public static Vector3 ToXXX(this Vector2 me)
		{
			return new Vector3(me.x, me.x, me.x);
		}

		public static Vector3 ToXXY(this Vector2 me)
		{
			return new Vector3(me.x, me.x, me.y);
		}

		public static Vector3 ToXX0(this Vector2 me)
		{
			return new Vector3(me.x, me.x, 0);
		}

		public static Vector3 ToXX1(this Vector2 me)
		{
			return new Vector3(me.x, me.x, 1);
		}

		public static Vector3 ToXYX(this Vector2 me)
		{
			return new Vector3(me.x, me.y, me.x);
		}

		public static Vector3 ToXYY(this Vector2 me)
		{
			return new Vector3(me.x, me.y, me.y);
		}

		public static Vector3 ToXY0(this Vector2 me)
		{
			return new Vector3(me.x, me.y, 0);
		}

		public static Vector3 ToXY1(this Vector2 me)
		{
			return new Vector3(me.x, me.y, 1);
		}

		public static Vector3 ToX0X(this Vector2 me)
		{
			return new Vector3(me.x, 0, me.x);
		}

		public static Vector3 ToX0Y(this Vector2 me)
		{
			return new Vector3(me.x, 0, me.y);
		}

		public static Vector3 ToX00(this Vector2 me)
		{
			return new Vector3(me.x, 0, 0);
		}

		public static Vector3 ToX01(this Vector2 me)
		{
			return new Vector3(me.x, 0, 1);
		}

		public static Vector3 ToX1X(this Vector2 me)
		{
			return new Vector3(me.x, 1, me.x);
		}

		public static Vector3 ToX1Y(this Vector2 me)
		{
			return new Vector3(me.x, 1, me.y);
		}

		public static Vector3 ToX10(this Vector2 me)
		{
			return new Vector3(me.x, 1, 0);
		}

		public static Vector3 ToX11(this Vector2 me)
		{
			return new Vector3(me.x, 1, 1);
		}

		public static Vector3 ToYXX(this Vector2 me)
		{
			return new Vector3(me.y, me.x, me.x);
		}

		public static Vector3 ToYXY(this Vector2 me)
		{
			return new Vector3(me.y, me.x, me.y);
		}

		public static Vector3 ToYX0(this Vector2 me)
		{
			return new Vector3(me.y, me.x, 0);
		}

		public static Vector3 ToYX1(this Vector2 me)
		{
			return new Vector3(me.y, me.x, 1);
		}

		public static Vector3 ToYYX(this Vector2 me)
		{
			return new Vector3(me.y, me.y, me.x);
		}

		public static Vector3 ToYYY(this Vector2 me)
		{
			return new Vector3(me.y, me.y, me.y);
		}

		public static Vector3 ToYY0(this Vector2 me)
		{
			return new Vector3(me.y, me.y, 0);
		}

		public static Vector3 ToYY1(this Vector2 me)
		{
			return new Vector3(me.y, me.y, 1);
		}

		public static Vector3 ToY0X(this Vector2 me)
		{
			return new Vector3(me.y, 0, me.x);
		}

		public static Vector3 ToY0Y(this Vector2 me)
		{
			return new Vector3(me.y, 0, me.y);
		}

		public static Vector3 ToY00(this Vector2 me)
		{
			return new Vector3(me.y, 0, 0);
		}

		public static Vector3 ToY01(this Vector2 me)
		{
			return new Vector3(me.y, 0, 1);
		}

		public static Vector3 ToY1X(this Vector2 me)
		{
			return new Vector3(me.y, 1, me.x);
		}

		public static Vector3 ToY1Y(this Vector2 me)
		{
			return new Vector3(me.y, 1, me.y);
		}

		public static Vector3 ToY10(this Vector2 me)
		{
			return new Vector3(me.y, 1, 0);
		}

		public static Vector3 ToY11(this Vector2 me)
		{
			return new Vector3(me.y, 1, 1);
		}

		public static Vector3 To0XX(this Vector2 me)
		{
			return new Vector3(0, me.x, me.x);
		}

		public static Vector3 To0XY(this Vector2 me)
		{
			return new Vector3(0, me.x, me.y);
		}

		public static Vector3 To0X0(this Vector2 me)
		{
			return new Vector3(0, me.x, 0);
		}

		public static Vector3 To0X1(this Vector2 me)
		{
			return new Vector3(0, me.x, 1);
		}

		public static Vector3 To0YX(this Vector2 me)
		{
			return new Vector3(0, me.y, me.x);
		}

		public static Vector3 To0YY(this Vector2 me)
		{
			return new Vector3(0, me.y, me.y);
		}

		public static Vector3 To0Y0(this Vector2 me)
		{
			return new Vector3(0, me.y, 0);
		}

		public static Vector3 To0Y1(this Vector2 me)
		{
			return new Vector3(0, me.y, 1);
		}

		public static Vector3 To00X(this Vector2 me)
		{
			return new Vector3(0, 0, me.x);
		}

		public static Vector3 To00Y(this Vector2 me)
		{
			return new Vector3(0, 0, me.y);
		}

		public static Vector3 To000(this Vector2 me)
		{
			return new Vector3(0, 0, 0);
		}

		public static Vector3 To001(this Vector2 me)
		{
			return new Vector3(0, 0, 1);
		}

		public static Vector3 To01X(this Vector2 me)
		{
			return new Vector3(0, 1, me.x);
		}

		public static Vector3 To01Y(this Vector2 me)
		{
			return new Vector3(0, 1, me.y);
		}

		public static Vector3 To010(this Vector2 me)
		{
			return new Vector3(0, 1, 0);
		}

		public static Vector3 To011(this Vector2 me)
		{
			return new Vector3(0, 1, 1);
		}

		public static Vector3 To1XX(this Vector2 me)
		{
			return new Vector3(1, me.x, me.x);
		}

		public static Vector3 To1XY(this Vector2 me)
		{
			return new Vector3(1, me.x, me.y);
		}

		public static Vector3 To1X0(this Vector2 me)
		{
			return new Vector3(1, me.x, 0);
		}

		public static Vector3 To1X1(this Vector2 me)
		{
			return new Vector3(1, me.x, 1);
		}

		public static Vector3 To1YX(this Vector2 me)
		{
			return new Vector3(1, me.y, me.x);
		}

		public static Vector3 To1YY(this Vector2 me)
		{
			return new Vector3(1, me.y, me.y);
		}

		public static Vector3 To1Y0(this Vector2 me)
		{
			return new Vector3(1, me.y, 0);
		}

		public static Vector3 To1Y1(this Vector2 me)
		{
			return new Vector3(1, me.y, 1);
		}

		public static Vector3 To10X(this Vector2 me)
		{
			return new Vector3(1, 0, me.x);
		}

		public static Vector3 To10Y(this Vector2 me)
		{
			return new Vector3(1, 0, me.y);
		}

		public static Vector3 To100(this Vector2 me)
		{
			return new Vector3(1, 0, 0);
		}

		public static Vector3 To101(this Vector2 me)
		{
			return new Vector3(1, 0, 1);
		}

		public static Vector3 To11X(this Vector2 me)
		{
			return new Vector3(1, 1, me.x);
		}

		public static Vector3 To11Y(this Vector2 me)
		{
			return new Vector3(1, 1, me.y);
		}

		public static Vector3 To110(this Vector2 me)
		{
			return new Vector3(1, 1, 0);
		}

		public static Vector3 To111(this Vector2 me)
		{
			return new Vector3(1, 1, 1);
		}

		#endregion Vector2 to Vector3

		#region Vector3 Ext

		//public static bool operator ==(Vector3 lhs, Vector3 rhs)
		//{
		//	return Vector3.SqrMagnitude(lhs - rhs) < 9.99999944E-11f;
		//}

		public static bool SafeEqual(Vector3 a, Vector3 b)
		{
			return Vector3.SqrMagnitude(a - b) < 0.0001;
		}

		public static Vector3 Abs(this Vector3 me)
		{
			return new Vector3(Mathf.Abs(me.x), Mathf.Abs(me.y), Mathf.Abs(me.z));
		}

		public static Vector3 RandomRotation()
		{
			Vector3 me = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
			return me;
		}

		public static Vector3 ReturnMultByCoeffXY(this Vector3 vec, Vector2 coeffXY)
		{
			return new Vector3(vec.x * coeffXY.x, vec.y * coeffXY.y, vec.z);
		}

		public static Vector3 ReturnMultByCoeffXY(this Vector3 vec, float coeffX, float coeffY)
		{
			return new Vector3(vec.x * coeffX, vec.y * coeffY, vec.z);
		}

		public static Vector3 ReturnMultByCoeff2D(this Vector3 vec, float coeff)
		{
			return new Vector3(vec.x * coeff, vec.y * coeff, vec.z);
		}



		public static Vector3 LerpTo(this Vector3 me, Vector3 towards, float t)
		{
			return Vector3.Lerp(me, towards, t);
		}

		public static Vector3 SlerpTo(this Vector3 me, Vector3 towards, float t)
		{
			return Vector3.Slerp(me, towards, t);
		}

		public static Vector3 Reflect(this Vector3 me, Vector3 byNormal)
		{
			return Vector3.Reflect(me, byNormal);
		}

		public static Vector3 Round(this Vector3 me)
		{

			return new Vector3(Mathf.Round(me.x), Mathf.Round(me.y), Mathf.Round(me.z));
		}

		public static Vector3 Ceil(this Vector3 me)
		{
			return new Vector3(Mathf.Ceil(me.x), Mathf.Ceil(me.y), Mathf.Ceil(me.z));
		}

		public static Vector3 Floor(this Vector3 me)
		{
			return new Vector3(Mathf.Floor(me.x), Mathf.Floor(me.y), Mathf.Floor(me.z));
		}

		public static float DistanceSqr(this Vector3 me, Vector3 other)
		{
			return (me - other).sqrMagnitude;
		}

		public static float Distance(this Vector3 me, Vector3 other)
		{
			return Vector3.Distance(me, other);
		}

		public static float Dot(this Vector3 me, Vector3 other)
		{
			return Vector3.Dot(me, other);
		}

		public static Vector3 Multiply(this Vector3 me, Vector3 other)
		{
			me.Scale(other);
			return me;
		}

		public static Vector3 Normalized(this Vector3 me)
		{
			return me.normalized;
		}

		public static float SqrMagnitude(this Vector3 me)
		{
			return me.sqrMagnitude;
		}

		public static float Magnitude(this Vector3 me)
		{
			return me.magnitude;
		}

		public static Vector3 Cross(this Vector3 me, Vector3 other)
		{
			return Vector3.Cross(me, other);
		}

		public static Vector3 Towards(this Vector3 from, Vector3 to)
		{
			return to - from;
		}

		public static Vector3 SetX(this Vector3 target, float newX)
		{
			target.x = newX;
			return target;
		}
		public static Vector3 SetY(this Vector3 target, float newY)
		{
			target.y = newY;
			return target;
		}
		public static Vector3 SetZ(this Vector3 target, float newZ)
		{
			target.z = newZ;
			return target;
		}

		public static Vector3 AddX(this Vector3 target, float addX)
		{
			target.x += addX;
			return target;
		}
		public static Vector3 AddY(this Vector3 target, float addY)
		{
			target.y += addY;
			return target;
		}
		public static Vector3 AddZ(this Vector3 target, float addZ)
		{
			target.z += addZ;
			return target;
		}

		public static Vector3 Zero(this Vector3 me)
		{
			me = Vector3.zero;
			return me;
		}

		public static Vector3 GetMiddlePoint(this Vector3 first, Vector3 second) => (first + second) / 2f;

		#endregion Vector3 Ext

		#region Vector3 to Vector2
		public static Vector2 ToXX(this Vector3 me)
		{
			return new Vector2(me.x, me.x);
		}

		public static Vector2 ToXY(this Vector3 me)
		{
			return new Vector2(me.x, me.y);
		}

		public static Vector2 ToXZ(this Vector3 me)
		{
			return new Vector2(me.x, me.z);
		}

		public static Vector2 ToX0(this Vector3 me)
		{
			return new Vector2(me.x, 0);
		}

		public static Vector2 ToX1(this Vector3 me)
		{
			return new Vector2(me.x, 1);
		}

		public static Vector2 ToYX(this Vector3 me)
		{
			return new Vector2(me.y, me.x);
		}

		public static Vector2 ToYY(this Vector3 me)
		{
			return new Vector2(me.y, me.y);
		}

		public static Vector2 ToYZ(this Vector3 me)
		{
			return new Vector2(me.y, me.z);
		}

		public static Vector2 ToY0(this Vector3 me)
		{
			return new Vector2(me.y, 0);
		}

		public static Vector2 ToY1(this Vector3 me)
		{
			return new Vector2(me.y, 1);
		}

		public static Vector2 ToZX(this Vector3 me)
		{
			return new Vector2(me.z, me.x);
		}

		public static Vector2 ToZY(this Vector3 me)
		{
			return new Vector2(me.z, me.y);
		}

		public static Vector2 ToZZ(this Vector3 me)
		{
			return new Vector2(me.z, me.z);
		}

		public static Vector2 ToZ0(this Vector3 me)
		{
			return new Vector2(me.z, 0);
		}

		public static Vector2 ToZ1(this Vector3 me)
		{
			return new Vector2(me.z, 1);
		}

		public static Vector2 To0X(this Vector3 me)
		{
			return new Vector2(0, me.x);
		}

		public static Vector2 To0Y(this Vector3 me)
		{
			return new Vector2(0, me.y);
		}

		public static Vector2 To0Z(this Vector3 me)
		{
			return new Vector2(0, me.z);
		}

		public static Vector2 To00(this Vector3 me)
		{
			return new Vector2(0, 0);
		}

		public static Vector2 To01(this Vector3 me)
		{
			return new Vector2(0, 1);
		}

		public static Vector2 To1X(this Vector3 me)
		{
			return new Vector2(1, me.x);
		}

		public static Vector2 To1Y(this Vector3 me)
		{
			return new Vector2(1, me.y);
		}

		public static Vector2 To1Z(this Vector3 me)
		{
			return new Vector2(1, me.z);
		}

		public static Vector2 To10(this Vector3 me)
		{
			return new Vector2(1, 0);
		}

		public static Vector2 To11(this Vector3 me)
		{
			return new Vector2(1, 1);
		}
		#endregion
	}
}