using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;

    CharacterController characterController;
    Animator chracteranim;
    Vector3 moveVector;
    public float speed = 3.4f;

    public bool move=false,paint=false;

    public GameObject startpanel;
    

    public float targetVelocity = 2.0f;
    public int numberOfRays = 10;
    public float angle = 90;

    public float rayRange = 0.5f;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        chracteranim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (move == true)
        {
            MoveCharacter();
        }

        var deltaPosition = Vector3.zero;
        for (int i = 0; i < numberOfRays; ++i)
        {
            var rotation = this.transform.rotation;
            var rotationMod = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * angle * 2 - angle, this.transform.up);
            var direction = rotation * rotationMod * Vector3.forward;

            var ray = new Ray(this.transform.position, direction);
            RaycastHit hitinfo;
            if (Physics.Raycast(ray, out hitinfo, rayRange))
            {
                if (hitinfo.collider.tag == "Wall")
                {
                    Debug.Log("paint");
                    paint = true;
                }

                
                

            }
            

        }



    }

    private void MoveCharacter()
    {
        
        moveVector = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        moveVector=transform.TransformDirection(moveVector);
        characterController.Move(moveVector);
    }

    public void RunStart()
    {
        chracteranim.SetBool("run", true);
        move = true;
        startpanel.gameObject.SetActive(false);
    }

    
    
    

    private void OnDrawGizmos()
    {
        for (int i = 0; i < numberOfRays; ++i)
        {
            var rotation = this.transform.rotation;
            var rotationMod = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * angle * 2 - angle, this.transform.forward);
            var direction = rotation * rotationMod * Vector3.forward;
            Gizmos.DrawRay(this.transform.position, direction);

        }
    }
}

