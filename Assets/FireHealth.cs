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

    LinkedList<ParticleEmitter> particles = new LinkedList<ParticleEmitter>();

	// Use this for initialization
	void Start ()
	{
		fireOut = transform.FindChild ("OuterCore").GetComponent<ParticleEmitter> ();
		fireIn = transform.FindChild ("InnerCore").GetComponent<ParticleEmitter> ();
		fireSmoke = transform.FindChild ("smoke").GetComponent<ParticleEmitter> ();


		flameOut = transform.FindChild ("Flame").FindChild ("OuterCore").GetComponent<ParticleEmitter>();
		flameIn = transform.FindChild ("Flame").FindChild ("InnerCore").GetComponent<ParticleEmitter>();
		flameSmoke = transform.FindChild ("Flame").FindChild ("Smoke").GetComponent<ParticleEmitter>();

        particles.AddLast(fireOut);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
