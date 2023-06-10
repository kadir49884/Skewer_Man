using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upperpik;

public enum ParticleType
{
	Default,
}

namespace Upperpik.Managers
{
	[CreateAssetMenu(menuName = "Upperpik/Managers/ParticleManager")]
	public class ParticleManager : ScriptableBase
	{
		[SerializeField, AssetsOnly] private GameObject[] particles;

		public void GetParticle(ParticleType type = ParticleType.Default, Vector3 position = default, Vector3 scale = default, Vector3 rotation = default, Transform parent = null, float destroyTime = 3f)
		{
			GameObject prefabParticle = particles.Find(a => a.name == type.ToString());

			if (!prefabParticle)
				return;

			GameObject particle = Instantiate(prefabParticle, parent);
			particle.transform.position = position;
			if (scale != default)
				particle.transform.localScale = scale;
			if (rotation != default)
				particle.transform.eulerAngles = rotation;

			particle.SetActive(true);


			var main = particle.GetComponent<ParticleSystem>().main;

			if (!main.playOnAwake)
				particle.GetComponent<ParticleSystem>().Play();

			Destroy(particle, destroyTime);
		}
	}

}