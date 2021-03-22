using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    RaycastHit hit;

    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    
    void Update()
    {
        if(Physics.Raycast(transform.position,transform.forward,out hit, 0.3f))
        {
            if (hit.transform.tag == "Obstacle")
            {
                TakeDamage(1);
            }
            
        }

        if (currentHealth <= 0)
        {
            PaintingWall.intance.RestartPanel.gameObject.SetActive(true);
        }
    }

    


    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
