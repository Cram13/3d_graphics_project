using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_effects : MonoBehaviour
{   
    public enum EffectName
    {
        Fire, Poison, Ice
    }
    public GameObject EffektFire;
    public GameObject EffektPoison;
    public GameObject EffektIce;
    public Character_stats character_stats;
    public bool[] hasEffekt = {false,false,false};
    public float[] effectTimeLeft = {0,0,0};
    public float[] effectDamage = {0,0,0};
    public float[] effectDamageTime = {0.1f,0.5f,1f};
    private GameObject[] effectGameObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        character_stats = GetComponentInParent<Character_stats>();
        effectGameObjects = new GameObject[] {EffektFire, EffektPoison, EffektIce};
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_stats.playerStats.enable_keys_for_testing && Input.GetKeyDown(KeyCode.P)){
            addEffect(EffectName.Poison,10,2);
        }
        if (Player_stats.playerStats.enable_keys_for_testing && Input.GetKeyDown(KeyCode.F)){
            addEffect(EffectName.Fire,10,2);
        }
        if (Player_stats.playerStats.enable_keys_for_testing && Input.GetKeyDown(KeyCode.I)){
            addEffect(EffectName.Ice,0,2);
        }
    }
    
    public void addEffect(EffectName effectName, float damage, float time){
        if(!hasEffekt[(int)effectName]){
            effectDamage[(int)effectName] = damage;
            effectTimeLeft[(int)effectName] = time;
            hasEffekt[(int)effectName] = true;
            effectGameObjects[(int)effectName].SetActive(true);
            StartCoroutine(applyEffect(effectName));
        }
    }
    void doDamage(float damage){
        character_stats.TakeDamage(damage);
    }
    void removeEffekt(EffectName effectName){
        hasEffekt[(int)effectName] = false;
        effectGameObjects[(int)effectName].SetActive(false);

    }
    public void removeAllEffekts(){
        StopAllCoroutines();
        removeEffekt(EffectName.Fire);
        removeEffekt(EffectName.Ice);
        removeEffekt(EffectName.Poison);
    }
    IEnumerator applyEffect(EffectName effectName){
        int num_of_damages = (int)(effectTimeLeft[(int)effectName]/effectDamageTime[(int)effectName]);
        float singel_damage = effectDamage[(int)effectName]/num_of_damages;
        for(int i=0;i<num_of_damages;i++){
            if(hasEffekt[(int)effectName]){
                yield return new WaitForSeconds(effectDamageTime[(int)effectName]);
                doDamage(singel_damage);
            }
        }
        removeEffekt(effectName);
    }
}
