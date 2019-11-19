using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move_enemy : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    private bool _move=true;
    public bool move {get{return _move;} set{_move = value; agent.isStopped = !value;}}
    // Start is called before the first frame update
    void Start()
    {
        player = Player_stats.player.transform;
        agent.speed = gameObject.GetComponent<Enemy_stats>().movementSpeed.GetValue();
    }

    // Update is called once per frame
    void Update()
    {
        if(_move){
            agent.SetDestination(player.position);
        }
    }
}
