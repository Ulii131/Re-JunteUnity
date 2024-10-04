using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayer : MonoBehaviour
{
    [SerializeField] private int health = 3;

    [SerializeField] private HealthSystem healthSystem;


    private void Start()
    {
        healthSystem.InitHealth(health);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health--;
            healthSystem.ChangeNowHealth(health);
            Debug.Log("Pierdes una vida");

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
