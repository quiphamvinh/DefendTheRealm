using UnityEngine;

public class CombatUnitController : MonoBehaviour
{
    [Header("Detection Settings")]
    [SerializeField] private float detectionRange = 5f;

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
}