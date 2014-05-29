using UnityEngine;
using System.Collections;

public class HoseFollowPlayer : MonoBehaviour {

    LineRenderer line;
    int count = 0;

    float spawnDelay = 0.05f;
    float lastSpawnTime = 0;

    Vector3 lastSavedPosition;

    RaycastHit groundPos;
	int layerMask;

	// Use this for initialization
	void Start ()
    {
        line = GetComponent<LineRenderer>();

        AddNewPoint(transform.position);

		layerMask = ~(1<<9);
	

        Physics.Raycast(transform.position, -transform.up, out groundPos, 10f, layerMask);


	}
	
    void Update()
    {
        if (spawnDelay + lastSpawnTime < Time.time && (lastSavedPosition - Camera.main.transform.position).magnitude > 0.4f )
        {
			Physics.Raycast(Camera.main.transform.position - Camera.main.transform.forward, -transform.up, out groundPos,  10f, layerMask);

            lastSpawnTime = Time.time;

            AddNewPoint(Camera.main.transform.position);
        }
    }

	// Update is called once per frame
	void AddNewPoint (Vector3 position)
    {
        if (count > 0)
        {
		//	line.SetPosition(count-1, new Vector3(lastSavedPosition.x, groundPos.point.y + 0.3f, lastSavedPosition.z));
        }

        count += 1;
        line.SetVertexCount(count);
        line.SetPosition(count-1, new Vector3(position.x, groundPos.point.y + 0.3f, position.z));
        lastSavedPosition = position;
	}
}
