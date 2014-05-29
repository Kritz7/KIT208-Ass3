using UnityEngine;
using System.Collections;

public class SwingAxe : MonoBehaviour {

	PickUp pickUp;
	bool swingForward = false;
	bool swingBackwards = false;
	bool swing = false;
	bool swinging = false;

	Vector3 originalPickupPosition;
	Quaternion forwardSwingRotation;

	// Use this for initialization
	void Start ()
	{
		pickUp = GameObject.Find("First Person Controller").GetComponent<PickUp>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(pickUp.axePickedUp && originalPickupPosition == Vector3.zero)
		{
			originalPickupPosition = pickUp.axe.transform.GetChild(0).position;
			//forwardSwingRotation = pickUp.hands.transform.rotation * Quaternion.Euler(new Vector3(-80, 20, 0)); 

			Debug.DrawLine(Vector3.zero, originalPickupPosition, Color.blue, 10f);
		}

		swing = !swinging && pickUp.equiped == 2 && Input.GetKeyDown (KeyCode.Mouse0);


		if(swing)
		{
			swinging = true;
			swingForward = true;

			forwardSwingRotation = pickUp.hands.transform.rotation * Quaternion.Euler(new Vector3(80, 0, 30));
		}

		if(swinging)
		{
			if(swingForward)
			{
				transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, forwardSwingRotation, 30f * Time.deltaTime);

				if((transform.parent.rotation.eulerAngles - forwardSwingRotation.eulerAngles).magnitude < 0.5f)
				{
					swingBackwards = true;
					swingForward = false;
				}
			}

			if(swingBackwards)
			{
				transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, pickUp.hands.transform.rotation, 20f * Time.deltaTime);
				
				if((transform.parent.rotation.eulerAngles - pickUp.hands.transform.rotation.eulerAngles).magnitude < 0.2f)
				{
					swingBackwards = false;
					swinging = false;
				}
			}
		}
	}
}
