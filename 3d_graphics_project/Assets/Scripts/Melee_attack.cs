using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_attack : MonoBehaviour
{
    //private Collider col;
    private Enemy_stats enemy_Stats;
    //private float damage;
    private Player_stats player_stats;
    private bool player_in_range;
    // Start is called before the first frame update
    void Awake(){
        //col = GetComponent<Collider>();
        enemy_Stats = GetComponentInParent<Enemy_stats>();
        //damage = enemy_Stats.attack.GetValue();
    }
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider col){
       if(col.gameObject.layer == 8 /*Player*/){//if multiplayer added need fix
            player_stats = col.gameObject.GetComponent<Player_stats>();
            player_in_range = true;
       }
    }
    void OnTriggerExit(Collider col){
       if(col.gameObject.layer == 8 /*Player*/){
            player_in_range = false;
       }

    }

    // Update is called once per frame
    void Update()
    {
        if(player_in_range){
            if(enemy_Stats.attackReady){
                player_stats.TakeDamage(enemy_Stats.attack.GetValue());
            }
        }
    }
}
