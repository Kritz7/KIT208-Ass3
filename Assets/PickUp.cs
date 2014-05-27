using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUp : MonoBehaviour {
	bool fireHosePickedUp = false;
	bool axePickedUp = false;
	bool targetPickedUp = false;
	int equiped = 0;
	
	GameObject fireHose = null;
	GameObject axe = null;
	GameObject target = null;
	
	GameObject hands = null;
	
	
	// Use this for initialization
	void Start () {
		hands = GameObject.Find("Main Camera/Hands");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (fireHose != null) {
			fireHose.transform.position = hands.transform.position;
			fireHose.transform.rotation = hands.transform.rotation;
		}
		if (axe != null) {
			axe.transform.position = hands.transform.position;
			axe.transform.rotation = hands.transform.rotation;
		}
		if (target != null) {
			target.transform.position = hands.transform.position;
			target.transform.rotation = hands.transform.rotation;
		}
		
		if (equiped == 1) {
			if (fireHosePickedUp) {
				fireHose.SetActive(true);
				if (axePickedUp) {
					axe.SetActive(false);
				}
				if (targetPickedUp) {
					target.SetActive(false);
				}
			}
			else {
				equiped = 2;
			}
		}
		if(equiped == 2) {
			if (axePickedUp) {
				axe.SetActive(true);
				if(fireHosePickedUp){
					fireHose.SetActive(false);
				}
				if (targetPickedUp) {
					target.SetActive(false);
				}
			}
			else {
				equiped = 3;
			}
		}

		if (equiped == 3) {
			if (targetPickedUp) {
				target.SetActive(true);
				if (fireHosePickedUp){
					fireHose.SetActive(false);
				}
				if (axePickedUp) {
					axe.SetActive(false);
				}
			}
			else {
				equiped = 1;
			}
		}
		if (equiped == 4) {
			equiped = 1;
		}

		if (!fireHosePickedUp && !axePickedUp && !targetPickedUp) {
			equiped = 0;
		}
	

		if (Input.GetAxis("Mouse ScrollWheel") != 0) {
			equiped += 1;
			print ("Switching equiped item");

		}
	}
	
	void OnTriggerEnter(Collider other) {
		string item = other.gameObject.name;
		if (item == "Fire Hose") {
			fireHosePickedUp = true;
			fireHose = other.gameObject;
			equiped = 1;
			print ("Fire Hose " + fireHose.name);
		}
		else if (item == "Axe") {
			axePickedUp = true;
			axe = other.gameObject;
			equiped = 2;
			print ("Axe " + axe.name);
		}
		else if (item == "Target") {
			targetPickedUp = true;
			target = other.gameObject;
			equiped = 3;
			print ("Target " + target.name);
		}
	}
}
