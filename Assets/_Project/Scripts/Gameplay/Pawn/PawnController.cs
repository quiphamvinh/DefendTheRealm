using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : MonoBehaviour     // quản lý state hiện tại, chuyển state,..
{
    private PawnState currentState;
    private void Start()
    {
        Debug.Log("Pawn FSM Ready");
    }
    private void Update()
    {
        // nếu currentState khác null -> gọi Update()
        currentState?.Update();
        // nếu viết currentState.Update() thì nếu currentState = null -> Crash.
    }
    public void ChangeState(PawnState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}
