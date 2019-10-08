using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player_stats))]
public class Player_attack : MonoBehaviour
{
    public GameObject attackObj;
    private Camera mainCam;
    private Player_stats player_stats;
    public float projectile_speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        player_stats = gameObject.GetComponent<Player_stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")){
            if(player_stats.attackReady){
                Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit);
                Vector3 direction = (hit.point - transform.position);
                direction.y = 0;
                direction = direction.normalized;
                GameObject bullet = Instantiate(attackObj, transform.position+direction, new Quaternion());
                bullet.GetComponent<Rigidbody>().velocity = direction.normalized *projectile_speed;
                Do_damage do_damage = bullet.GetComponent<Do_damage>();
                do_damage.damage = player_stats.attack.GetValue();
                do_damage.damageLayer = 9;
            }
        }
    }
}
