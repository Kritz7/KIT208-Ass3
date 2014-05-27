using UnityEngine;
using System.Collections;

public class DetectWater : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnParticleCollision(GameObject other)
	{
		if(other.name == "FireEffect")
		{
			FireHealth fire;
			fire = other.GetComponent<FireHealth>();

			fire.PutOutFire(0.1f * Time.deltaTime);
		}
	}
}
