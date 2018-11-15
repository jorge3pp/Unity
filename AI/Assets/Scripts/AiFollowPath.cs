using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiFollowPath : MonoBehaviour {

    public PathMarker Target;
    public NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        Move();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Move()
    {
        agent.destination = Target.transform.position;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PathMarker")
        {
            Target = other.gameObject.GetComponent<PathMarker>().NextMarker;
            //Target = Target.NextMarker; // Does the same
            Move();
        }
    }

}
