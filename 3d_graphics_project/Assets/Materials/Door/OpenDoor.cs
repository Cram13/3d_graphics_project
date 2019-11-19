using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Animator anim;
    private static Animator currentDoor;

    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.Play("Idle");
        currentDoor = anim;
    }

    void OnEnable(){
        currentDoor = anim;
        currentDoor.Play("ClosedDoor", 0, 0);
    }
    public static void openDoor(){
        currentDoor.Play("AnimationDoor", 0, 0);
    }    
    public static void closeDoor(){
        currentDoor.Play("ClosedDoor", 0, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenDoor.openDoor();
        }
    }
}
