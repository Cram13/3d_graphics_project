using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode_attack : MonoBehaviour
{
    //private Collider col;
    private Enemy_stats enemy_Stats;
    private Move_enemy move_Enemy;
    //private float damage;
    private Player_stats player_stats;
    private bool player_in_range;
    private bool exploding;
    [SerializeField]
    private float explosionDelay = 1;
    [SerializeField]
    private GameObject explosionPrefab = null;
    public bool[] statusEffekt = {false,false,false};
    public float[] effectDamage = {0,0,0};
    // Start is called before the first frame update
    void Awake(){
        enemy_Stats = GetComponentInParent<Enemy_stats>();
        move_Enemy = GetComponentInParent<Move_enemy>();
    }
    public void attack(){

    }
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider col){
       if(col.gameObject.layer == 8 /*Player*/){//if multiplayer added need fix
            player_stats = col.gameObject.GetComponent<Player_stats>();
            player_in_range = true;
            if(!exploding){
                exploding = true;
                StartCoroutine(explodeDelay());
            }
       }
    }
    void OnTriggerExit(Collider col){
       if(col.gameObject.layer == 8 /*Player*/){
            player_in_range = false;
       }

    }

    IEnumerator explodeDelay(){
        move_Enemy.move = false;
        yield return new WaitForSeconds(explosionDelay);
        GameObject explosion = Instantiate(explosionPrefab, transform.position, new Quaternion());
        Explosion_damage do_damage = explosion.GetComponent<Explosion_damage>();
        do_damage.damage = enemy_Stats.attack.GetValue();
        do_damage.damageLayer = 8 /*Player*/;
        do_damage.statusEffekt = statusEffekt;
        do_damage.effectDamage = effectDamage;
        exploding = false;
        move_Enemy.move = true;
        enemy_Stats.Die();
    }

}
