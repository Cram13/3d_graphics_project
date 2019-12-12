using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_system : MonoBehaviour
{
    private bool isPaused=false;
    [SerializeField]
    private GameObject PauseMenu = null;
    // Start is called before the first frame update
    void Start()
    {
            PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!isPaused){
                Pause();
            }
            else{
                Resume();
            }
        }
    }
    public void Pause(){
        PauseMenu.SetActive(true);
        isPaused=true;
        Time.timeScale = 0.0f;

    }
    public void Resume(){
        PauseMenu.SetActive(false);
        isPaused=false;
        Time.timeScale = 1.0f;

    }
}
