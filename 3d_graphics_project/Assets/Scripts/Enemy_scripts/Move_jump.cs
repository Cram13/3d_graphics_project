using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_jump : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce = 1.0f;
    public float jumpFrequence = 1;
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
        /*if (Input.GetKeyDown(KeyCode.J)){
            jump();
        }*/
    }
    void jump(){
        float angle = Random.Range(-20.0f,20.0f);
        rb.AddForce(Quaternion.Euler(0, angle, 0) * (Player_stats.player.transform.position - transform.position).normalized*jumpForce);
    }
    IEnumerator coroutineJump(){
        while(true){
            yield return new WaitForSeconds(1/jumpFrequence);
            jump();
        }
    }
}
