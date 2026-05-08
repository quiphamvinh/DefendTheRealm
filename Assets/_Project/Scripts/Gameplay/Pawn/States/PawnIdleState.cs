using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnIdleState : PawnState
{
    public PawnIdleState(PawnController pawn) : base(pawn)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter Idle State");
    }

    public override void Update()
    {
    }

    public override void Exit()
    {
        Debug.Log("Exit Idle State");
    }
}
