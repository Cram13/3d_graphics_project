using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum collectabel_type {Currency, Experience, Health};
public class Collectable : MonoBehaviour
{
    public float collectDistance = 5;
    public float attractionForce = 10;
    public int value = 0;
    public int collectabelType = (int)collectabel_type.Currency;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnTriggerEnter(Collider col){
       if(col.gameObject.layer == 8 /*Player*/){
           if((int)collectabel_type.Currency==collectabelType){
                Debug.Log("Todo: collected Currency with value " + value);
           }
           else if((int)collectabel_type.Experience==collectabelType){
                Debug.Log("Todo: collected Experience with value " + value);
           }
           else if((int)collectabel_type.Health==collectabelType){
                Debug.Log("Todo: collected Health with value " + value);
           }
            Destroy(gameObject);
       }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if((Player_stats.player.transform.position-transform.position).magnitude < collectDistance){
            rb.AddForce((Player_stats.player.transform.position-transform.position).normalized * attractionForce);
        }
    }
}
