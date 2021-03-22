using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Zoom : MonoBehaviour
{
    int zoom = 30;

    void Start()
    {
        
    }

    
    void Update()
    {

        if (PlayerMove.instance.paint == true)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime);
        }

    }
}
