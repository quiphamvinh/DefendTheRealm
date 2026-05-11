using UnityEngine;

public class PawnReturnState : PawnState
{
    public PawnReturnState(PawnController pawn) : base(pawn)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter Return State");

        Vector3 basePosition = pawn.HomeBase.transform.position;

        pawn.ChangeState(
            new PawnMoveState(
                pawn,
                basePosition,
                () =>
                {
                    pawn.DepositResources();
                    pawn.ChangeState(new PawnIdleState(pawn));
                }
            )
        );
    }
}