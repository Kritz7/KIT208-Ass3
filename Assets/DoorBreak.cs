using UnityEngine;
using System.Collections;

public class DoorBreak : MonoBehaviour {

    bool broken = false;

	PickUp pickUp;

	void Start()
	{
		pickUp = GameObject.Find("First Person Controller").GetComponent<PickUp>();
	}

	// Update is called once per frame
	void OnMouseDown () {

        float dist = (transform.position - Camera.main.transform.position).magnitude;

		if(!broken && dist<10f && pickUp.equiped == 2) BreakDoor();
	}

    void BreakDoor()
    {
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
        transform.GetComponent<BoxCollider>().size *= 0.4f;

        gameObject.layer = 10;

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 0.4f, transform.localScale.z);
                                        

        rigidbody.AddForce(Camera.main.transform.forward * 300);
    }
}
