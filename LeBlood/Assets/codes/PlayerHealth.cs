using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // maximum health of the player
    public int currentHealth; // current health of the player
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        // check if player is dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // do death related actions here, such as calling a game over screen
        Destroy(gameObject);
    }
}
