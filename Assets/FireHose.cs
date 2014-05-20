using UnityEngine;
using System.Collections;

public class FireHose : MonoBehaviour {

	ParticleEmitter waterEmitter;

	// Use this for initialization
	void Start ()
	{
		waterEmitter = transform.FindChild ("WaterHose").GetComponent<ParticleEmitter> ();
		waterEmitter.emit = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		waterEmitter.emit = Input.GetKey (KeyCode.Mouse0);
	}

	void LateUpdate ()
	{
		waterEmitter.transform.rotation = Camera.main.transform.rotation * Quaternion.Euler (new Vector3 (90, 0, 0));
	}
}
