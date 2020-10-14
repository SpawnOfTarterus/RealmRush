using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int maxHealth = 1;
    int health = 1;

    private void Start()
    {
        var spawner = FindObjectOfType<EnemySpawner>();
        maxHealth = spawner.GetMaxHealth();
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            GetComponent<Enemy>().Die();
        }
        else
        {
            GetComponent<Enemy>().PlayHitFX();
        }
    }
}
