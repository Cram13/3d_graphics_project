using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health_bar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage = null;

    private void Awake(){
        GetComponentInParent<Character_stats>().onHealthChanged += HandleHealthChange;
    }

    private void HandleHealthChange(float current, float max){
        foregroundImage.fillAmount = current/max;
    }
    
    private void LateUpdate(){
        transform.LookAt(Camera.main.transform.position);
        transform.Rotate(0,180,0);
    }
}
