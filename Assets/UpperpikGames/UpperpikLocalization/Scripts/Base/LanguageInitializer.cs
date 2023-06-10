using Sirenix.OdinInspector;
using UnityEngine;
using Upperpik;

public class LanguageInitializer : MonoBehaviour
{
	private static LanguageInitializer instance;

	public LocalizationBase[] Languages { get; set; }

	public static LanguageInitializer Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<LanguageInitializer>();
				if (instance == null)
				{
					GameObject obj = new GameObject();
					obj.name = typeof(LanguageInitializer).Name;
					instance = obj.AddComponent<LanguageInitializer>();
					instance.Languages = Resources.LoadAll<LocalizationBase>("Languages");
				}
			}
			return instance;
		}
	}

	[SerializeField, ReadOnly] private LocalizationBase activeLanguage;

	public LocalizationBase ActiveLanguage { get => activeLanguage; }

	private TextLanguageUpdater[] textUpdaters;

	public void Init(LocalizationBase selectedLanguage = null)
	{
		if (selectedLanguage == null)
		{
			activeLanguage = Languages.Find(language => language.Language == Application.systemLanguage);
			if (activeLanguage == null)
				activeLanguage = Languages.Find(language => language.Language == SystemLanguage.English);
		}
		else
			activeLanguage = selectedLanguage;
	}

	public void UpdateActiveLanguage()
	{
		Init();
		textUpdaters = FindObjectsOfType<TextLanguageUpdater>();
		textUpdaters.ForEach(t => t.UpdateText());
	}
}