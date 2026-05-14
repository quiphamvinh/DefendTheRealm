using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BaseController targetBase;
    private UnitMovement movement;

    private void Awake()
    {
        movement = GetComponent<UnitMovement>();
    }

    private void Start()
    {
        MoveToBase();
    }

    private void MoveToBase()
    {
        movement.MoveTo(targetBase.transform.position);
    }
}
