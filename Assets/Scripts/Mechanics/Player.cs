using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 1000;
    private int health;

    public GameManager gameManager;
    public HealthBar healthBar;
    public AudioSource hitSound;

    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void Damage(int damage)
    {
        health -= damage;
        hitSound.Play();
        healthBar.SetHealth(health);
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
        gameManager.EndGame();
    }
}
