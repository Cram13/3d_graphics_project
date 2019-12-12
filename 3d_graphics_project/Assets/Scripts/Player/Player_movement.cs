using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{   
    private float movementSpeed;
    private Vector3 direction = new Vector3();
    private bool moving = false;
    private bool was_moving = false;
    [SerializeField]
    private Animation animation = null;
    [SerializeField]
    private string name_move_animation = "";
    [SerializeField]
    private string name_idle_animation = "";
    [SerializeField]
    private float movementMargin = 0.1f;
    [SerializeField]
    private bool moveSideways = true;
    [SerializeField]
    private float backwards_slow_percentage = 0.0f;
    [SerializeField]
    private float sidewardswards_slow_percentage = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = Player_stats.playerStats.movementSpeed.GetValue();
    }

    void FixedUpdate(){
        transform.position += direction * movementSpeed * Time.fixedDeltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        movementSpeed = Player_stats.playerStats.movementSpeed.GetValue();
        if(moveSideways){
            direction = new Vector3();
            direction.x += Input.GetAxis("Horizontal");
            direction.z += Input.GetAxis("Vertical");
            direction = direction.normalized;
            /*direction.x *= 1.0f-sidewardswards_slow_percentage; // in this mode not useful but maybe for a 3 mode
            if(Input.GetAxis("Vertical")<0){
                direction.z *= 1.0f-backwards_slow_percentage;
            }*/

        }
        else{
            direction = Input.GetAxis("Vertical")*transform.forward;
            direction = direction.normalized;
            if(Input.GetAxis("Vertical")<0){
                direction *= 1.0f-backwards_slow_percentage;
            }
        }
        if(direction.magnitude>movementMargin){
            moving = true;
            if(!was_moving){
                animation.Play(name_move_animation);
                was_moving = true;
            }
        }
        else{
            moving = false;
            if(was_moving){
            animation.Play(name_idle_animation);
            was_moving = false;
            }
        }
        
    }
}
