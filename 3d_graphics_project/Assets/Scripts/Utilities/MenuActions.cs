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
    public void OnLoadGame(Scene scene, LoadSceneMode mode){
        if(scene.name == Game){
            Shop_system.shop.load();
        }
    }
    public void switchToLoadGameScene(){
        SceneManager.LoadScene(Game);
        SceneManager.sceneLoaded += OnLoadGame;
    }
    public void switchToIntroScene(){
        SceneManager.LoadScene(Intro);
    }
    public void switchToEndScene(){
        SceneManager.LoadScene(End);
    }
    
    public void exitGame(){
        if(Shop_system.shop != null){
            Shop_system.shop.save();
        }
        Application.Quit();
    }
}
