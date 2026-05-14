using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 0;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Current HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }

    }
    private void Die()
    {
        Debug.Log($"{gameObject.name} died");

        Destroy(gameObject);
    }
}
