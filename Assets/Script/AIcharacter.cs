using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcharacter : MonoBehaviour
{
    public float targetVelocity = 9f;
    public int numberOfRays = 10;
    public float angle = 90;

    public float rayRange = 1.5f;

    Animator aıchracteranim;

    // Start is called before the first frame update
    void Start()
    {
        aıchracteranim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.instance.move == true)
        {
            aıchracteranim.SetBool("playermove", true);
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
                    deltaPosition -= (0.6f / numberOfRays) * targetVelocity * direction;
                    if (hitinfo.collider.tag == "Wall")
                    {
                        Debug.Log("AIfinish");
                        Destroy(this.gameObject);
                    }
                    if (hitinfo.collider.tag == "Girl")
                    {
                        deltaPosition -= (0.6f / numberOfRays) * targetVelocity * direction;
                    }
                }
                else
                {
                    deltaPosition += (0.6f / numberOfRays) * targetVelocity * direction;
                }

            }
            this.transform.position += deltaPosition * Time.deltaTime;
        }

        
    }
    private void OnDrawGizmos()
    {
        for(int i = 0; i < numberOfRays; ++i)
        {
            var rotation = this.transform.rotation;
            var rotationMod= Quaternion.AngleAxis((i /((float) numberOfRays-1)) * angle*2-angle, this.transform.forward);
            var direction = rotation * rotationMod * Vector3.forward;
            Gizmos.DrawRay(this.transform.position, direction);

        }
    }
}
