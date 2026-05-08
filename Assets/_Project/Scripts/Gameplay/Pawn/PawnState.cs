using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// "abtract" để ko dùng trực tiếp, chỉ để kế thừa
public abstract class PawnState      // mọi state kế thừa từ đây: IdleState, GatherState, etc.
{
    protected PawnController pawn;
    public PawnState(PawnController pawn)
    {
        this.pawn = pawn;
    }
    public virtual void Enter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }
}
