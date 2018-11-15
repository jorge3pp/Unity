using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AiController : MonoBehaviour {
    public enum states
    {
        Patrolling,
        MovingToTarget,
        Attacking
    }

    public PathMarker Target;
    public states estado;
    public NavMeshAgent agent;
    public List<NavMeshAgent> enemies;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        var agents = GetComponents<NavMeshAgent>();
        foreach(NavMeshAgent agent in agents)
        {
            if (agent.tag == "Enemy")
            {
                enemies.Add(agent);
            }
        }
	}
	
    private void Patrol()
    {
        agent.destination = Target.transform.position;

    }

	// Update is called once per frame
	void Update () {
        if (states.Patrolling == estado) Patrol();
        if (states.MovingToTarget == estado) MoveToTarget();
    }

    private void MoveToTarget()
    {
        Debug.Log("Enemies: " + enemies.Count);
        NavMeshAgent closestEnemy = enemies[0];
        foreach(NavMeshAgent enemy in enemies)
        {
            if(Vector3.Distance(agent.transform.position, enemy.transform.position) < Vector3.Distance(agent.transform.position, closestEnemy.transform.position))
            {
                closestEnemy = enemy;
            }
        }

        if (Vector3.Distance(agent.transform.position, closestEnemy.transform.position)<3)
        {
            agent.destination = agent.transform.position;
        }
        else agent.destination = closestEnemy.transform.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PathMarker")
        {
            Target = other.gameObject.GetComponent<PathMarker>().NextMarker;
            Patrol();
        }
    }
}
