using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_jump : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce = 1.0f;
    public float jumpFrequence = 1;
    [SerializeField]
    private float speedRot=1;
    private bool jumping = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(coroutineJump());
    }
    void OnEnable(){
        StartCoroutine(coroutineJump());
    }

    // Update is called once per frame
    void Update()
    {
        if(!jumping){
            Vector3 targetDirection = Player_stats.player.transform.position - transform.position;
            targetDirection.y = 0;

            // The step size is equal to speed times frame time.
            float singleStep = speedRot * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
    void jump(){
        float angle = Random.Range(-20.0f,20.0f);
        rb.AddForce(Quaternion.Euler(0, angle, 0) * transform.forward.normalized*jumpForce);
    }
    IEnumerator coroutineJump(){
        while(true){
            yield return new WaitForSeconds(1/jumpFrequence);
            jumping = true;
            jump();
            do{
                yield return null;
            } while ( rb.velocity.magnitude > 0.01 );
            jumping = false;
        }
    }
}
