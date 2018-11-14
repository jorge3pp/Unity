using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class AiFollowCursor : MonoBehaviour {

    NavMeshAgent agent;
    RaycastHit result;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))// left mouse button
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out result, 100))
            {
                if (result.collider != null)
                {
                    MoveTo(result.point);
                }
            }
            DrawPath();
        }
	}

    void MoveTo(Vector3 location)
    {
        agent.destination = location;
    }

    void DrawPath()
    {
        if(agent.path.corners.Length> 0){
            for(int i=0; i < agent.path.corners.Length; i++)
            {
                if (!(i + 1 >= agent.path.corners.Length))
                {
                    Debug.DrawLine(
                        agent.path.corners[i],
                        agent.path.corners[i + 1],
                        Color.red);
                }
            }
        }
    }
}
