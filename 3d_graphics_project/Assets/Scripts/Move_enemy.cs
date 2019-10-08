using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move_enemy : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent.speed = gameObject.GetComponent<Enemy_stats>().movementSpeed.GetValue();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
}
