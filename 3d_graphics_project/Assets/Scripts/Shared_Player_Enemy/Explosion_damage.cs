using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_damage : MonoBehaviour
{   
    public int damageLayer = 9; /*9 for enemy, 8 for player*/
    public float damage {get; set;}
    public bool[] statusEffekt = {false,false,false};
    public float[] effectDamage = {0,0,0};
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.layer == damageLayer){
            Character_stats character_stats = col.gameObject.GetComponent<Character_stats>();
            for(int i=0; i<statusEffekt.Length;i++){
                if(statusEffekt[i]){
                    character_stats.status_effects.addEffect((Status_effects.EffectName)i, effectDamage[i],1);
                }
            }
            character_stats.TakeDamage(damage);
        }
        Destroy(gameObject, 0.1f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
