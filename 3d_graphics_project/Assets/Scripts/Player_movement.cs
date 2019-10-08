using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{   
    private float movementSpeed;
    private Vector3 direction = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = gameObject.GetComponent<Player_stats>().movementSpeed.GetValue();
    }

    void FixedUpdate(){
        direction = new Vector3();
        direction.x += Input.GetAxis("Horizontal");
        direction.z += Input.GetAxis("Vertical");
        transform.position += direction * movementSpeed * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
