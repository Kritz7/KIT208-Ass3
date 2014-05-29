using UnityEngine;
using System.Collections;

public class LockCursor : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Screen.lockCursor = true;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!Screen.lockCursor)
            Screen.lockCursor = true;
	}
}
