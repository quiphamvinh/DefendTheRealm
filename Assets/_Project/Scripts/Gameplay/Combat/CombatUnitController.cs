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

    private CombatState currentState;

    public EnemyController CurrentTarget => currentTarget;

    public float AttackRange => attackRange;

    private void Awake()
    {
        movement = GetComponent<UnitMovement>();

        ChangeState(
            new CombatIdleState(this)
        );
    }

    public void ChangeState(CombatState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter();
    }

    private void Update()
    {
        currentState.Update();
    }

    public void MoveToTarget()
    {
        if (currentTarget == null)
        {
            return;
        }

        movement.MoveTo(currentTarget.transform.position);
    }

    public void FindTarget()
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

    public void Attack()
    {
        if (currentTarget == null)
        {
            return;
        }

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown)
        {
            attackTimer = 0f;

            Health targetHealth = currentTarget.GetComponent<Health>();

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