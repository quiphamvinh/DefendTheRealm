using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : MonoBehaviour     // quản lý state hiện tại, chuyển state,..
{
    private PawnState currentState;
    public UnitMovement Movement { get; private set; }

    [Header("References")]
    [SerializeField] private BaseController homeBase;
    public BaseController HomeBase => homeBase;

    [Header("Inventory")]
    [SerializeField] private int inventoryCapacity = 10;
    [SerializeField] private int currentInventory = 0;

    private void Awake()
    {
        Movement = GetComponent<UnitMovement>();
    }

    private void Start()
    {
        Debug.Log("Pawn FSM Ready");
        ChangeState(new PawnIdleState(this));
    }

    public bool IsInventoryFull()
    {
        return currentInventory >= inventoryCapacity;
    }

    public void AddResource(int amount)
    {
        currentInventory += amount;
    }

    public void DepositResources()
    {
        homeBase.Deposit(currentInventory);

        currentInventory = 0;
    }

    private void Update()
    {
        // nếu currentState khác null -> gọi Update()
        currentState?.Update();
        // nếu viết currentState.Update() thì nếu currentState = null -> Crash.

        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                ResourceNode resourceNode = hit.collider.GetComponent<ResourceNode>();

                if (resourceNode != null)
                {
                    ChangeState(
                        new PawnMoveState(
                            this,
                            resourceNode.transform.position,
                            () =>
                            {
                                ChangeState(new PawnGatherState(this, resourceNode));
                            }
                        )
                    ); 
                    return;
                }
            }

            ChangeState(new PawnMoveState(this, mousePos));
        }
    }

    public void ChangeState(PawnState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}
