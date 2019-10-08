using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_client : MonoBehaviour
{
    [SerializeField]
    private float healthDrop = 0;
    [SerializeField]
    private int minCurrencyDrop = 10;
    [SerializeField]
    private int maxCurrencyDrop = 100;
    [SerializeField]
    private int minExperienceDrop = 10;
    [SerializeField]
    private int maxExperienceDrop = 100;
    
    public void DropStuff(){
        Drop_system.instance.Drop(transform, minCurrencyDrop, maxCurrencyDrop, minExperienceDrop, maxExperienceDrop, healthDrop);
    }
}
