using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshObstacle))]
[RequireComponent(typeof(Rigidbody))]
public class DoorController : MonoBehaviour {

    NavMeshObstacle obstacle;
    Rigidbody body;

    public bool IsLocked;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        obstacle = GetComponent < NavMeshObstacle > ();
        Unlock();
	}

    private void Unlock()
    {
        obstacle.carving = false;
        body.isKinematic = false;
        IsLocked = false;
    }

    private void Lock()
    {
        obstacle.carving = true;
        body.isKinematic = true;
        IsLocked = true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
