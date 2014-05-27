using UnityEngine;
using System.Collections;

public class open_door : MonoBehaviour {

	bool open = false;
	GameObject hinge;

	bool opening = false;
	bool closing = false;

	Vector3 startRotation;
	Vector3 endRotation;

	// Use this for initialization
	void Start ()
	{
		startRotation = transform.parent.rotation.eulerAngles;
		endRotation = startRotation + new Vector3 (0, 90, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(opening)
		{
			closing = false;
			transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, Quaternion.Euler(endRotation), 0.8f * Time.deltaTime);

			if((transform.parent.rotation.eulerAngles - endRotation).magnitude < 0.5f)
			{
				opening = false;
			}
		}

		else if(closing)
		{
			opening = false;
			transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, Quaternion.Euler(startRotation), 0.8f * Time.deltaTime);

			if((transform.parent.rotation.eulerAngles - startRotation).magnitude < 0.5f)
			{
				closing = false;
			}
		}
	}

	void OnMouseDown () 
	{
		open = !open;

		if(open)
		{
			opening = true;
			closing = false;
		}

		if(!open)
		{
			closing = true;
			opening = false;
		}
	}
}
