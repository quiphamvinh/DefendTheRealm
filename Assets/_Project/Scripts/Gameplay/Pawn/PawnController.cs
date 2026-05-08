using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : MonoBehaviour     // quản lý state hiện tại, chuyển state,..
{
    private PawnState currentState;
    public UnitMovement Movement { get; private set; }
    private void Awake()
    {
        Movement = GetComponent<UnitMovement>();
    }
    private void Start()
    {
        Debug.Log("Pawn FSM Ready");
        ChangeState(new PawnIdleState(this));
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
