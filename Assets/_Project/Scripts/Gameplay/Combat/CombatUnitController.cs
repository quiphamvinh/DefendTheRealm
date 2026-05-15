using UnityEngine;

public class CombatUnitController : MonoBehaviour
{
    [Header("Detection Settings")]
    [SerializeField] private float detectionRange = 5f;

    [Header("Attack Settings")]
    [SerializeField] private int damage = 10;

    [SerializeField] private float attackRange = 1.5f;

    [SerializeField] private float attackCooldown = 1f;

    private float attackTimer;

    private UnitMovement movement;

    private EnemyController currentTarget;

    private void Awake()
    {
        movement = GetComponent<UnitMovement>();
    }

    private void Update()
    {
        if (currentTarget == null)
        {
            FindTarget();

            return;
        }


        float distance = Vector3.Distance(transform.position, currentTarget.transform.position);

        if (distance <= attackRange)
        {
            Attack();
        }
    }

    private void FindTarget()
    {
        EnemyController[] enemies = FindObjectsOfType<EnemyController>();

        float closestDistance = Mathf.Infinity;

        EnemyController closestEnemy = null;

        foreach (EnemyController enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < closestDistance && distance <= detectionRange)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            currentTarget = closestEnemy;

            movement.MoveTo(currentTarget.transform.position);

            Debug.Log($"Target Found: {currentTarget.name}");
        }
    }

    private void Attack()
    {
        if (currentTarget == null)
        {
            return;
        }

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown)
        {
            attackTimer = 0f;

            Health targetHealth =
                currentTarget.GetComponent<Health>();

            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damage);

                Debug.Log("Combat Unit Attacked Enemy");
            }

            if (currentTarget == null)
            {
                return;
            }
        }
    }

}