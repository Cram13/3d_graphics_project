using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Player_stats))]
public class Player_attack : MonoBehaviour
{
    public GameObject attackObj;
    private Camera mainCam;
    private Player_stats player_stats;
    public float projectile_speed = 10;
    public bool shootDiagonal = false;
    public bool shootDoubleFront = false;
    public bool splashDamage = false;

    public bool shootBack = false;
    public bool bigBullet = false;

    
    public bool[] statusEffekt = {false,false,false};
    public float[] effectDamage = {0,0,0};
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(12/*Bullets*/, 12/*Bullets*/, true);
        mainCam = Camera.main;
        player_stats = gameObject.GetComponent<Player_stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && !EventSystem.current.IsPointerOverGameObject()){
            if(player_stats.attackReady){
                //Vector3 direction = AimAt();
                if(!shootDoubleFront){
                    ShootBullet(transform.forward, transform.position);
                }
                if(shootDoubleFront){
                    Vector3 displacement = Vector3.Cross(transform.forward, transform.up).normalized * 0.5f;
                    ShootBullet(transform.forward, transform.position + displacement);
                    ShootBullet(transform.forward, transform.position - displacement);
                }
                if(shootDiagonal){
                    //Vector3 rotatedVector = Quaternion.AngleAxis(30, Vector3.up) * originalVector;
                    ShootBullet(Quaternion.AngleAxis( 30, Vector3.up) * transform.forward, transform.position);
                    ShootBullet(Quaternion.AngleAxis(-30, Vector3.up) * transform.forward, transform.position);
                }
                if(shootBack){
                    ShootBullet(-transform.forward, transform.position);
                }
            }
        }
    }
    
    private void ShootBullet(Vector3 direction, Vector3 startPos){
        GameObject bullet = Instantiate(attackObj, startPos+direction, new Quaternion());
        bullet.GetComponent<Rigidbody>().velocity = direction.normalized *projectile_speed;
        Do_damage do_damage = bullet.GetComponent<Do_damage>();
        do_damage.damage = player_stats.attack.GetValue();
        do_damage.damageLayer = 9;
        do_damage.splashDamage = splashDamage;
        do_damage.statusEffekt = statusEffekt;
        do_damage.effectDamage = effectDamage;
        if(bigBullet){
            bullet.transform.localScale *= 2;
        }
    }
}
