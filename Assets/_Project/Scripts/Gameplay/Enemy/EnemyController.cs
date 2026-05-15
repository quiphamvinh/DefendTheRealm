using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BaseController targetBase;

    [Header("Attack Settings")]
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackCooldown = 1f;

    private float attackTimer;

    private Health baseHealth;

    private UnitMovement movement;

    private void Awake()
    {
        movement = GetComponent<UnitMovement>();
        targetBase = FindAnyObjectByType<BaseController>();
        baseHealth = targetBase.GetComponent<Health>();
    }

    private void Start()
    {
        MoveToBase();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, targetBase.transform.position);
        if (distance <= attackRange)
        {
            Attack();
        }
    }

    private void MoveToBase()
    {
        movement.MoveTo(targetBase.transform.position);
    }

    private void Attack()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown)
        {
            attackTimer = 0f;

            baseHealth.TakeDamage(damage);

            Debug.Log("Enemy attacked Base");
        }
    }
}
