using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireHealth : MonoBehaviour {

	ParticleEmitter fireOut;
	ParticleEmitter fireIn;
	ParticleEmitter fireSmoke;

	ParticleEmitter flameOut;
	ParticleEmitter flameIn;
	ParticleEmitter flameSmoke;

	Light lightSource;

	List<ParticleEmitter> particles = new List<ParticleEmitter>();
	List<float> currentParticleEmitStrength = new List<float>();

	float maxFireIntensity = 1;
	float minFireIntensity = 0;

	public float currentFireIntensity;

	// Use this for initialization
	void Start ()
	{
		currentFireIntensity = maxFireIntensity;

		fireOut = transform.FindChild ("OuterCore").GetComponent<ParticleEmitter> ();
		fireIn = transform.FindChild ("InnerCore").GetComponent<ParticleEmitter> ();
		fireSmoke = transform.FindChild ("smoke").GetComponent<ParticleEmitter> ();


		flameOut = transform.FindChild ("Flame").FindChild ("OuterCore").GetComponent<ParticleEmitter>();
		flameIn = transform.FindChild ("Flame").FindChild ("InnerCore").GetComponent<ParticleEmitter>();
		flameSmoke = transform.FindChild ("Flame").FindChild ("Smoke").GetComponent<ParticleEmitter>();

		lightSource = transform.FindChild ("Flame").FindChild ("Lightsource").GetComponent<Light> ();

		particles.Add (fireOut);
		particles.Add (fireIn);
		particles.Add (fireSmoke);

		particles.Add (flameOut);
		particles.Add (flameIn);
		particles.Add (flameSmoke);

		foreach (ParticleEmitter p in particles)
		{
			currentParticleEmitStrength.Add(p.maxSize);
		}

		currentParticleEmitStrength.Add (lightSource.intensity);
	}

	public void PutOutFire(float amount)
	{
		SetFireIntensity (currentFireIntensity - amount);
	}

	void SetFireIntensity(float newCurrent)
	{
		currentFireIntensity = Mathf.Clamp (newCurrent, minFireIntensity, maxFireIntensity);

		foreach (ParticleEmitter p in particles)
		{
			int indexOfCurrent = particles.IndexOf(p);

			p.maxSize = currentParticleEmitStrength[indexOfCurrent] * currentFireIntensity;
			p.minSize = currentParticleEmitStrength[indexOfCurrent] * currentFireIntensity;
		}

		lightSource.intensity = currentParticleEmitStrength[currentParticleEmitStrength.Count-1] * currentFireIntensity;

		if (currentFireIntensity <= minFireIntensity)
		{
			this.collider.enabled = false;
		}
	}
}
