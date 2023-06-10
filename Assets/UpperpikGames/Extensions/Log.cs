using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Upperpik
{

	public enum Colors
	{
		aqua,
		black,
		blue,
		brown,
		cyan,
		darkblue,
		fuchsia,
		green,
		grey,
		lightblue,
		lime,
		magenta,
		maroon,
		navy,
		olive,
		purple,
		red,
		silver,
		teal,
		white,
		yellow
	}

	public enum Style
	{
		Bold,
		Italics
	}

	public static class Log
	{
		#region Utils
		public static string StrColored(this string message, Colors color)
		{
			return string.Format("<color={0}>{1}</color>", color.ToString(), message);
		}
		public static string StrStyled(this string message, Style style)
		{
			switch (style)
			{
				case Style.Bold:
					return string.Format("<b>{0}</b>", message);
				case Style.Italics:
					return string.Format("<i>{0}</i>", message);
			}
			return "Style Error";
		}
		#endregion

		public static void Message<T>(T message, bool isEditorMode = true)
		{
			if (isEditorMode)
			{
#if UNITY_EDITOR
				Debug.Log(message);
#endif
			}

		}

		public static void Message<T>(T[] messages, bool isEditorMode = true)
		{
			if (isEditorMode)
			{
#if UNITY_EDITOR
				foreach (var item in messages)
				{
					Debug.Log(item.ToString() + "\n");
				}
#endif
			}
		}

		public static void Message<T>(T message, Style style, bool isEditorMode = true)
		{
			string styledMessage = StrStyled(message.ToString(), style);
			if (isEditorMode)
			{
#if UNITY_EDITOR
				Debug.Log(styledMessage);
#endif
			}
		}

		public static void Message<T>(T message, Colors color, bool isEditorMode = true)
		{

			string coloredMessage = StrColored(message.ToString(), color);
			if (isEditorMode)
			{
#if UNITY_EDITOR
				Debug.Log(coloredMessage);
#endif
			}

		}

		public static void Message<T>(T message, Colors color, Style style, bool isEditorMode = true)
		{
			

			string CSmessage = StrColored(message.ToString(), color);
			CSmessage = StrStyled(CSmessage, style);

			if (isEditorMode)
			{
#if UNITY_EDITOR
				Debug.Log(CSmessage);
#endif
			}

		}
		////
		///
		public static void ErrorMessage<T>(T message, bool isEditorMode = true)
		{
			if (isEditorMode)
			{
#if UNITY_EDITOR
				Debug.LogError(message);
#endif
			}

		}

		public static void ErrorMessage<T>(T[] messages, bool isEditorMode = true)
		{
			if (isEditorMode)
			{
#if UNITY_EDITOR
				foreach (var item in messages)
				{
					Debug.LogError(item.ToString() + "\n");
				}
#endif
			}
		}

		public static void ErrorMessage<T>(T message, Style style, bool isEditorMode = true)
		{
			string styledMessage = StrStyled(message.ToString(), style);
			if (isEditorMode)
			{
#if UNITY_EDITOR
				Debug.LogError(styledMessage);
#endif
			}
		}

		public static void ErrorMessage<T>(T message, Colors color, bool isEditorMode = true)
		{

			string coloredMessage = StrColored(message.ToString(), color);
			if (isEditorMode)
			{
#if UNITY_EDITOR
				Debug.LogError(coloredMessage);
#endif
			}

		}

		public static void ErrorMessage<T>(T message, Colors color, Style style, bool isEditorMode = true)
		{


			string CSmessage = StrColored(message.ToString(), color);
			CSmessage = StrStyled(CSmessage, style);

			if (isEditorMode)
			{
#if UNITY_EDITOR
				Debug.LogError(CSmessage);
#endif
			}

		}

		///
		public static void WarningMessage<T>(T message, bool isEditorMode = true)
		{
			if (isEditorMode)
			{
#if UNITY_EDITOR
				Debug.LogWarning(message);
#endif
			}

		}

		public static void WarningMessage<T>(T[] messages, bool isEditorMode = true)
		{
			if (isEditorMode)
			{
#if UNITY_EDITOR
				foreach (var item in messages)
				{
					Debug.LogWarning(item.ToString() + "\n");
				}
#endif
			}
		}

		public static void WarningMessage<T>(T message, Style style, bool isEditorMode = true)
		{
			string styledMessage = StrStyled(message.ToString(), style);
			if (isEditorMode)
			{
#if UNITY_EDITOR
				Debug.LogWarning(styledMessage);
#endif
			}
		}

		public static void WarningMessage<T>(T message, Colors color, bool isEditorMode = true)
		{

			string coloredMessage = StrColored(message.ToString(), color);
			if (isEditorMode)
			{
#if UNITY_EDITOR
				Debug.LogWarning(coloredMessage);
#endif
			}

		}

		public static void WarningMessage<T>(T message, Colors color, Style style, bool isEditorMode = true)
		{
			string CSmessage = StrColored(message.ToString(), color);
			CSmessage = StrStyled(CSmessage, style);

			if (isEditorMode)
			{
#if UNITY_EDITOR
				Debug.LogWarning(CSmessage);
#endif
			}

		}

	}
}

