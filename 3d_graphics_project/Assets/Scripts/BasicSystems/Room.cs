using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<GameObject> Enemies;
    private int livingEnemies = 0;
    public event Action RoomSolved = delegate{};
    public GameObject startPos;
    public void removeEnemie(GameObject enemy){
        //Enemies.Remove(enemy);
        livingEnemies -= 1;
        if(livingEnemies == 0){
            RoomSolved();
        }
    }
    public void addEnemie(GameObject enemy){
        Enemies.Add(enemy);
        livingEnemies +=1;
    }
    // Start is called before the first frame update
    void Start()
    {
        livingEnemies = Enemies.Count;
        if(livingEnemies == 0){
            RoomSolved();
        }
    }

    public void resetRoom(){
        foreach(GameObject e in Enemies){
            e.gameObject.SetActive(true);
            e.gameObject.GetComponent<Enemy_stats>().reborn();
        }
        livingEnemies = Enemies.Count;
    }
}
