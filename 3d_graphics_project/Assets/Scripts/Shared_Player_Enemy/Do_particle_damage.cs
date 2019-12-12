using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Do_particle_damage : MonoBehaviour
{
    [SerializeField]
    private int damage_layer = 8;
    [SerializeField]
    private float damage_per_hit = 0.5f;
    void OnParticleCollision(GameObject other)
        {
            //Debug.Log("particle hit something "+other.layer);
            if(other.layer == damage_layer){
                Character_stats character_stats = other.GetComponent<Character_stats>();
                character_stats.TakeDamage(damage_per_hit);
                //Debug.Log("hit player with particle");
            }
        }
}
