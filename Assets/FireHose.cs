using UnityEngine;
using System.Collections;

public class FireHose : MonoBehaviour {

	ParticleEmitter waterEmitter;
	PickUp pickUp;

	// Use this for initialization
	void Start ()
	{
		pickUp = GetComponent<PickUp>();
		waterEmitter = GameObject.Find("WaterHose").GetComponent<ParticleEmitter> ();
		waterEmitter.emit = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		waterEmitter.emit = Input.GetKey (KeyCode.Mouse0) && pickUp.equiped == 1;
	}

	void LateUpdate ()
	{
		waterEmitter.transform.rotation = Camera.main.transform.rotation * Quaternion.Euler (new Vector3 (70, 0, 0));
	}
}
