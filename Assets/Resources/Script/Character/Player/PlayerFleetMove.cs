using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFleetMove : MonoBehaviour
{
    public GameObject playerStartingPoint;
    public GameObject enemyStartingPoint;

    public NavMeshAgent agent;

    public float tempSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        agent.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = enemyStartingPoint.transform.position;
    }
}
