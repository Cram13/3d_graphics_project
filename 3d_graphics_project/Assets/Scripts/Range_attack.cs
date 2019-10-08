using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range_attack : MonoBehaviour
{
    public GameObject attackObj;
    public float offset_distance = 1;
    public float projectile_speed = 10;
    private Enemy_stats enemy_Stats;
    // Start is called before the first frame update
    void Start()
    {
        enemy_Stats = GetComponentInParent<Enemy_stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy_Stats.attackReady){
                //Ray ray = new Ray(transform.position, Player_stats.player.transform.position- transform.position);//mainCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Vector3 direction = Player_stats.player.transform.position- transform.position;
                //Physics.Raycast(ray, out hit);
                if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity)){
                    if(hit.collider.gameObject.layer == 8 /*player*/){
                        GameObject bullet = Instantiate(attackObj, transform.position+direction.normalized*offset_distance, new Quaternion());
                        bullet.GetComponent<Rigidbody>().velocity = direction.normalized *projectile_speed;
                        Do_damage do_damage = bullet.GetComponent<Do_damage>();
                        do_damage.damage = enemy_Stats.attack.GetValue();
                        do_damage.damageLayer = 8;
                    }
                }
            }
    }
}
