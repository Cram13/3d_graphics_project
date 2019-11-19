using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeaveThroghtDoor : MonoBehaviour
{
    
    public event Action leaveRoom = delegate{};
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider col){
       if(col.gameObject.layer == 8 /*Player*/){
           leaveRoom();
       }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
