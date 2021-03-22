using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float sensivity = 5;
    private float rotateY=0,rotateX=0;

    #region Mobile Rotate Values

    /*private Touch initTouch = new Touch();
    public Camera cam;
    private Vector3 origRot;
    public float dir = -1;*/

    #endregion

    void Start()
    {
        #region Mobile Rotate Values Assign
        /*origRot = cam.transform.eulerAngles;
        rotateX = origRot.x;
        rotateY = origRot.y;*/
        #endregion
    }


    void Update()
    {
        if (PlayerMove.instance.move == true)
        {
            RotatePlayerBody();
        }
        
    }

    private void RotatePlayerBody()
    {
        
        rotateX += sensivity * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(rotateY, rotateX, 0);
    }


    #region Mobile Rotate

    /*private void FixedUpdate()
    {
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = initTouch.position.x - touch.position.x;
                float deltaY = initTouch.position.y - touch.position.y;
                rotateY -= deltaY * Time.deltaTime * sensivity * dir;
                rotateX +=  sensivity * Input.GetAxis("Mouse X");
                transform.eulerAngles = new Vector3(rotate, rotateY, 0);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }
    }*/

    #endregion


}
