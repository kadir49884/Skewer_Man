using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;
using Upperpik;

public enum TextName
{
	Default

}
public class TextLanguageUpdater : MonoBehaviour
{
	[SerializeField] private TextName textName;

	[SerializeField] private Text[] texts;
	[SerializeField] private TextMesh[] textMeshes;

	private void OnEnable()
	{
		if (LanguageInitializer.Instance != null)
			UpdateText();
	}

	private void Start()
	{
		UpdateText();
	}

	public void UpdateText()
	{
		string str = "";

		switch (textName)
		{
			case TextName.Default:
				str = UpperUtil.DEFAULT;
				break;
			default:
				break;
		}

		if (str.Contains(";"))
		{
			string[] temp = str.Split(";".ToCharArray());
			str = temp[0] + "\n" + temp[1];
		}

		if (texts.Length != 0)
			texts.ForEach(t => t.text = str);
		else if (textMeshes.Length != 0)
			textMeshes.ForEach(t => t.text = str);
	}

	public void SetNewTextContent(string str)
	{
		if (str.Contains(";"))
		{
			string[] temp = str.Split(";".ToCharArray());
			str = temp[0] + "\n" + temp[1];
		}

		if (texts.Length != 0)
			texts.ForEach(t =>
			{
				t.lineSpacing = .85f;
				t.resizeTextMaxSize = 55;
				t.text = str;
			});
		else if (textMeshes.Length != 0)
			textMeshes.ForEach(t =>
			{
				t.lineSpacing = .85f;
				t.text = str;
			});
	}
}
