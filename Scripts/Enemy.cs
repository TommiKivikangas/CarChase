using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 50f;

    // If the enemys health goes to 0 or less Die() function is called
    public void TakeDamage(float amount) // amount is the amount of damage the enemy takes when hit.
    {
        health -= amount;
        if (health <= 0)
        {
            ScoreManager.instance.score += ScoreManager.instance.killPoints; // adds killpoints to score
            Die();
        }
    }
    // Destroys the enemy gameobject
    void Die()
    {
        Destroy(gameObject);
    }
}
