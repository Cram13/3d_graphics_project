using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_after_time : MonoBehaviour
{   
    public float live_time = 2.0f;
    private float time_cter = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time_cter>live_time){
            Destroy(gameObject);
        }
        time_cter += Time.deltaTime;
    }
}
