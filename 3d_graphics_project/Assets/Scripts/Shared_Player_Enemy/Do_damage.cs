using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Do_damage : MonoBehaviour
{   
    public float damage {get; set;}
    public int damageLayer = 9; /*9 for enemy, 8 for player*/
    public bool splashDamage = false;
    public bool blockable = true;
    
    public bool[] statusEffekt = {false,false,false};
    public float[] effectDamage = {0,0,0};
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.layer == damageLayer){
            Destroy(this.gameObject);
            if(splashDamage){
                // instanciate explosion prefab
                GameObject explosion = Instantiate(explosionPrefab, transform.position, new Quaternion());
                Explosion_damage do_damage = explosion.GetComponent<Explosion_damage>();
                do_damage.damage = damage;
                do_damage.damageLayer = damageLayer;
                do_damage.statusEffekt = statusEffekt;
                do_damage.effectDamage = effectDamage;
            }
            else{
                Character_stats character_stats = col.gameObject.GetComponent<Character_stats>();
                for(int i=0; i<statusEffekt.Length;i++){
                    if(statusEffekt[i]){
                        character_stats.status_effects.addEffect((Status_effects.EffectName)i, effectDamage[i],1);
                    }
                }
                character_stats.TakeDamage(damage);
            }
        }
        else if (col.gameObject.layer == 10/*RoomWalls*/){
            Destroy(this.gameObject);
        }
        else if (col.gameObject.layer == 12/*Bullets*/ && blockable){
            Destroy(this.gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {

        
    }
}
