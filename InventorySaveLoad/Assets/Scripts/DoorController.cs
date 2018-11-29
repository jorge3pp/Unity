using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorController : InteractiveObject {

    public bool isOpen = false;
    public float OpenYRotation = 90;

    public Transform Pivot;
    NavMeshObstacle navObstacle;

	// Use this for initialization
	void Start () {
        navObstacle = GetComponent<NavMeshObstacle>();

        if (isOpen)
        {
            transform.RotateAround(Pivot.position, Vector3.up, OpenYRotation);
        }
    }
	

	public override void Interact () {
        if (isOpen)
        {
            transform.RotateAround(Pivot.position, Vector3.up, OpenYRotation);
        }
        else
        {
            transform.RotateAround(Pivot.position, Vector3.up, -OpenYRotation);
        }

        navObstacle.carving = !navObstacle.carving;
	}
}
