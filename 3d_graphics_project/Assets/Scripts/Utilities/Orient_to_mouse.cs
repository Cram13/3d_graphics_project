using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orient_to_mouse : MonoBehaviour
{
    private Camera mainCam;
    public Transform orientObject;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPoint =  mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
        Vector3 floorPoint =  (mainCam.transform.position.y / (mainCam.transform.position.y - worldPoint.y))* (worldPoint-mainCam.transform.position);
        floorPoint += mainCam.transform.position;
        floorPoint.y = orientObject.position.y;
        gameObject.transform.LookAt(floorPoint);
    }
}
