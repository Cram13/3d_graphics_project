using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_on_dead : MonoBehaviour
{
    public List<GameObject> spawnObjects = new List<GameObject>();
    public float spawnCircleRadius = 3;
    void Start (){
		GetComponent<Character_stats>().OnDeath += spawnObjs;
	}
    void spawnObjs(){

        for(int i=0; i<spawnObjects.Count; i++){
            GameObject enemy = Instantiate(spawnObjects[i], transform.position + Quaternion.Euler(0, (360/spawnObjects.Count)*i, 0)* new Vector3(0,0,spawnCircleRadius),
                                             new Quaternion(), transform.parent);
            //Room_manager.activeRoom.addEnemie(enemy);
        }
    }

}
