using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upperpik;

public enum AudioType
{
	Default,
}

namespace Upperpik.Managers
{
	[CreateAssetMenu(menuName = "Upperpik/Managers/AudioManager")]
	public class AudioManager : ScriptableBase
	{
		[SerializeField] private AudioClip[] clips;

		public void PlayAudio(AudioType type)
		{
			if (PrefManager.GetSound == 0)
				return;

			AudioSource audio = new GameObject().AddComponent<AudioSource>();

			AudioClip clip = clips.Find(c => c.name.Equals(type.ToString(), System.StringComparison.OrdinalIgnoreCase));

			audio.clip = clip;
			audio.name = clip.name;

			audio.Play();

			Destroy(audio.gameObject, clip.length);
		}

		public AudioSource GetAudio(AudioType type)
		{
			if (PrefManager.GetSound == 0)
				return null;

			AudioSource audio = new GameObject().AddComponent<AudioSource>();

			AudioClip clip = clips.Find(c => c.name.Equals(type.ToString(), System.StringComparison.OrdinalIgnoreCase));

			if (clip == null)
				return null;

			audio.playOnAwake = false;
			audio.clip = clip;
			audio.name = clip.name;

			return audio;
		}
	}
}