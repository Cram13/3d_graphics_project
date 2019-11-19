using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public string Game = "Game";
    public string Intro = "Tutorial";
    public string End = "EndScene";
    public string MainMenu = "MainMenu";
    
    public void switchToNewGameScene(){
        SceneManager.LoadScene(Game);
    }    
    public void switchToMainMenuScene(){
        SceneManager.LoadScene(MainMenu);
    }
    public void switchToLoadGameScene(){
        Debug.Log("need to implement the loading/storing stuff");
        SceneManager.LoadScene(Game);
    }
    public void switchToIntroScene(){
        SceneManager.LoadScene(Intro);
    }
    public void switchToEndScene(){
        SceneManager.LoadScene(End);
    }
    
    public void exitGame(){
        Application.Quit();
    }
}
