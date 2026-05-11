using System;
using UnityEngine;

public class PawnMoveState : PawnState
{
    private Vector3 targetPosition;
    private Action onReachedTarget;

    public PawnMoveState(PawnController pawn, Vector3 targetPosition, Action onReachedTarget = null) : base(pawn)
    {
        this.targetPosition = targetPosition;
        this.onReachedTarget = onReachedTarget;
    }

    public override void Enter()
    {
        Debug.Log("Enter Move State");

        pawn.Movement.MoveTo(targetPosition);
    }

    public override void Update()
    {
        if (Vector3.Distance(pawn.transform.position, targetPosition) < 0.1f)
        {
            if (onReachedTarget != null)
            {
                onReachedTarget.Invoke();
            }
            else
            {
                pawn.ChangeState(new PawnIdleState(pawn));
            }
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Move State");
    }
}