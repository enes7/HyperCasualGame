using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallpercentage : MonoBehaviour
{
    public int maxwall;
    private int currentwall;
    // Start is called before the first frame update
    void Start()
    {
        currentwall = maxwall;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeductHealth(int damage)
    {
        currentwall = currentwall - damage;
    }
    public void AddPaint(int value)
    {
        currentwall = currentwall + value;
    }
}
