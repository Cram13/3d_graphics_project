using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDragon_Attack : MonoBehaviour
{
    [SerializeField]
    private Transform mouthPos = null;
    [SerializeField]
    private Animation anim = null;
    [SerializeField]
    private GameObject Fireball = null;
    [SerializeField]
    private GameObject FireStreamPrefab = null;
    [SerializeField]
    private string animFireBall="";
    [SerializeField]
    private string animFireStream="";
    [SerializeField]
    private string animIdle="";
    [SerializeField]
    private float offset_fireStream=0;
    [SerializeField]
    private float offset_fireball=0;
    [SerializeField]
    private float duration_fireStream=0;
    [SerializeField]
    private float speed_Fireball=0;
    private Enemy_stats enemy_Stats = null; // start
    private bool attack = false;
    private GameObject FireStream = null;
    [SerializeField]
    private bool shoot3 = false;
    [SerializeField]
    private bool shoot5 = false;
    [SerializeField]
    private bool[] statusEffekt = {false,false,false};
    [SerializeField]
    private float[] effectDamage = {0,0,0};
    [SerializeField]
    private float jumpForce=0;
    [SerializeField]
    private float jumpDuration=0;
    [SerializeField]
    private float jumpDelay=0;
    [SerializeField]
    private float speedRot=1;
    private Rigidbody rb=null;
    private float attackDelay=0;


    void Start()
    {
        FireStream = Instantiate(FireStreamPrefab, mouthPos.position, mouthPos.rotation * Quaternion.Euler(-90,0,0), mouthPos);
        FireStream.transform.localPosition = new Vector3(0,1,0);
        FireStream.SetActive(false);
        anim[animIdle].wrapMode = WrapMode.Loop;
        enemy_Stats = gameObject.GetComponent<Enemy_stats>();
        rb = gameObject.GetComponent<Rigidbody>();
        attackDelay = 1/enemy_Stats.attackSpeed.GetValue();
        enemy_Stats.onHealthChanged += getStrongerWithLessHP;
    }
    void getStrongerWithLessHP(float currenHP, float maxHP){
        if(currenHP/maxHP < 0.6f){
            shoot3 = true;
        }
        if(currenHP/maxHP < 0.3f){
            shoot5 = true;
        }
    }
    IEnumerator attackFireball(){
        attack = true;
        anim.Play(animFireBall);
        yield return new WaitForSeconds(offset_fireball);
        ShootFireball(transform.forward, mouthPos.position);
        if(shoot3){
            
        float angle3 = 15;
        ShootFireball(Quaternion.Euler(0,angle3,0) * transform.forward, mouthPos.position);
        ShootFireball(Quaternion.Euler(0,-angle3,0) * transform.forward, mouthPos.position);
        }
        if(shoot5){
        float angle5 = 30;
        ShootFireball(Quaternion.Euler(0,angle5,0) * transform.forward, mouthPos.position);
        ShootFireball(Quaternion.Euler(0,-angle5,0) * transform.forward, mouthPos.position);
        }
        do{
            yield return null;
        } while ( anim.isPlaying );
        StartCoroutine(nextAttack());
    }

    private void ShootFireball(Vector3 direction, Vector3 startPos){
        GameObject bullet = Instantiate(Fireball, startPos+direction, new Quaternion());
        bullet.GetComponent<Rigidbody>().velocity = direction.normalized *speed_Fireball;
        Do_damage do_damage = bullet.GetComponent<Do_damage>();
        do_damage.damage = enemy_Stats.attack.GetValue();
        do_damage.blockable = false;
        do_damage.damageLayer = 8;
        do_damage.splashDamage = false;
        do_damage.statusEffekt = statusEffekt;
        do_damage.effectDamage = effectDamage;
    }
    IEnumerator attackFireStream(){
        attack = true;
        anim.Play(animFireStream);
        yield return new WaitForSeconds(offset_fireStream);
        FireStream.SetActive(true);
        yield return new WaitForSeconds(duration_fireStream);
        FireStream.SetActive(false);
        do{
            yield return null;
        } while ( anim.isPlaying );
        StartCoroutine(nextAttack());
    }
    IEnumerator attackJump(){
        attack = true;
        yield return new WaitForSeconds(jumpDelay);
        rb.AddForce((Player_stats.player.transform.position - transform.position).normalized*jumpForce);
        yield return new WaitForSeconds(jumpDuration);
        do{
            yield return null;
        } while ( rb.velocity.magnitude > 0.01 );
        StartCoroutine(nextAttack());
    }
    IEnumerator nextAttack(){
        attack = false;
        anim.Play(animIdle);
        yield return new WaitForSeconds(attackDelay);
        switch(Random.Range(0,3)){
            case 0:
                StartCoroutine(attackFireball());
                break;
            case 1:
                StartCoroutine(attackFireStream());
                break;
            case 2:
                StartCoroutine(attackJump());
                break;
        }
    }
    void OnEnable(){
        StartCoroutine(nextAttack());
    }
    // Update is called once per frame
    void Update()
    {   
        if(!attack){

            // Determine which direction to rotate towards
            Vector3 targetDirection = Player_stats.player.transform.position - transform.position;
            targetDirection.y = 0;

            // The step size is equal to speed times frame time.
            float singleStep = speedRot * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            
            transform.rotation = Quaternion.LookRotation(newDirection);
            /*if(Input.GetKeyDown(KeyCode.V)){
                StartCoroutine(attackFireball());
            }
            if(Input.GetKeyDown(KeyCode.B)){
                StartCoroutine(attackFireStream());
            }
            if(Input.GetKeyDown(KeyCode.C)){
                StartCoroutine(attackJump());
                
            }*/

        }
    }

}
