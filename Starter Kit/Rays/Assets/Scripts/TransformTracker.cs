using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TransformTracker : MonoBehaviour {

    public Transform TransformToTrack;
    public bool DrawLine;
    public float Distance;
    public bool UseTrackingDistance;
    public float TrackingDistance = 100;

    LineRenderer line;
    RaycastHit result;
	// Use this for initialization
	void Start ()
    {
        line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(TransformToTrack);
        if (UseTrackingDistance && Vector3.Distance(transform.position, TransformToTrack.position) <= TrackingDistance)
        {
            #region Line positions

            if (DrawLine)
            {
                line.SetPosition(0, transform.position);

                if (Physics.Raycast(transform.position, transform.forward, out result, Distance))
                {
                    if (result.collider.tag != "Player")
                    {
                        line.SetPosition(1, result.point);
                        line.enabled = false;
                    }
                    else
                    {
                        line.enabled = true;
                        line.SetPosition(1, TransformToTrack.position);
                    }
                }

            }
            #endregion
        }
    }
    private void OnDrawGizmos()
    {
        if(gameObject.tag != "MainCamera")
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, TrackingDistance);
        }

    }
}
