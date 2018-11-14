using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMarker : MonoBehaviour {
    //retrieved by the AI when it collides with a PathMarker
    public PathMarker NextMarker;

    private void OnDrawGizmos()
    {
        if (NextMarker != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, NextMarker.transform.position);
        }
    }
}
