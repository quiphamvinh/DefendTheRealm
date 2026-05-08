using UnityEngine;

public class PawnMoveState : PawnState
{
    private Vector3 targetPosition;

    public PawnMoveState(PawnController pawn, Vector3 targetPosition) : base(pawn)
    {
        this.targetPosition = targetPosition;
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
            pawn.ChangeState(new PawnIdleState(pawn));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Move State");
    }
}