using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnGatherState : PawnState
{
    private ResourceNode resourceNode;
    private float gatherTimer;
    private float gatherInterval = 1f;

    public PawnGatherState(PawnController pawn, ResourceNode resourceNode) : base(pawn)
    {
        this.resourceNode = resourceNode;
    }

    public override void Enter()
    {
        Debug.Log("Enter Gather State");
    }

    public override void Update()
    {
        if (resourceNode == null || !resourceNode.HasResource())
        {
            pawn.ChangeState(new PawnIdleState(pawn)); return;
        }
        gatherTimer += Time.deltaTime;

        if (gatherTimer >= gatherInterval) 
        {
            GatherResource();
        }
    }

    private void GatherResource()
    {
        gatherTimer = 0f;

        int gatheredAmount = resourceNode.Gather(1);

        pawn.AddResource(gatheredAmount);

        Debug.Log($"Gathered: {gatheredAmount}");

        if (pawn.IsInventoryFull())
        {
            pawn.ChangeState(new PawnIdleState(pawn));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Gather State");
    }

}
