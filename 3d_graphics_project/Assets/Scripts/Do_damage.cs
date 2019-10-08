using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Do_damage : MonoBehaviour
{   
    public float damage {get; set;}
    public int damageLayer = 9; /*9 for enemy, 8 for player*/
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.layer == damageLayer){
            Destroy(this.gameObject);
            Character_stats character_stats = col.gameObject.GetComponent<Character_stats>();
            character_stats.TakeDamage(damage);
        }
        else if (col.gameObject.layer == 10/*RoomWalls*/){
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

        
    }
}
