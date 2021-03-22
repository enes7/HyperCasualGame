using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (PlayerMove.instance.move == true)
        {
            transform.Translate(0, 0, -1f * Time.deltaTime);
        }
        
    }
}
