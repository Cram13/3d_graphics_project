using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_system : MonoBehaviour
{
    public GameObject currency;
    public GameObject experience;
    public GameObject health;
    public int healthValue = 10;

    public void cleanDrops(){
        foreach(Transform child in transform){
            Destroy(child.gameObject);
        }

    }
    void DropCurrency(Transform trans, int min_amount, int max_amount){
        int ammount = Random.Range(min_amount, max_amount);
        GameObject obj = Instantiate(currency, trans.position, new Quaternion(), gameObject.transform);
        Collectable collectable = obj.GetComponent<Collectable>();
        collectable.value = ammount;
        collectable.collectabelType = (int)collectabel_type.Currency;
    }

    void DropExperience(Transform trans, int min_amount, int max_amount){
        int ammount = Random.Range(min_amount, max_amount);
        GameObject obj = Instantiate(experience, trans.position, new Quaternion(), gameObject.transform);
        Collectable collectable = obj.GetComponent<Collectable>();
        collectable.value = ammount;
        collectable.collectabelType = (int)collectabel_type.Experience;
    }

    void DropHealth(Transform trans, float drop_chance){
        bool drop = Random.Range(0.0f,1.0f)<drop_chance;
        if(drop){
            GameObject obj = Instantiate(experience, trans.position, new Quaternion(), gameObject.transform);
            Collectable collectable = obj.GetComponent<Collectable>();
            collectable.value = healthValue;
            collectable.collectabelType = (int)collectabel_type.Health;
        }
    }
    public void Drop(Transform trans, int min_amount_currency, int max_amount_currency,
                    int min_amount_experience, int max_amount_experience, float drop_chance_health){
                        DropCurrency(trans, min_amount_currency, max_amount_currency);
                        DropExperience(trans, min_amount_experience, max_amount_experience);
                        DropHealth(trans, drop_chance_health);
            }


    // s_Instance is used to cache the instance found in the scene so we don't have to look it up every time.
    public static Drop_system s_Instance = null;
    // A static property that finds or creates an instance of the manager object and returns it.
    public static Drop_system instance{
        get{
            if (s_Instance == null){
                // FindObjectOfType() returns the first AManager object in the scene.
                s_Instance = FindObjectOfType(typeof(Drop_system)) as Drop_system;
            }
            // If it is still null, create a new instance
            if (s_Instance == null){
                var obj = new GameObject("Drop_system");
                s_Instance = obj.AddComponent<Drop_system>();
            }
            return s_Instance;
        }
    }
 
    // Ensure that the instance is destroyed when the game is stopped in the editor.
    void OnApplicationQuit(){
        s_Instance = null;
    }
 
}
