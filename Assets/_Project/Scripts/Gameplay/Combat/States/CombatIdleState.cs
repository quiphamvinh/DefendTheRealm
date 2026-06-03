using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatIdleState : CombatState
{
    public CombatIdleState(CombatUnitController combatUnit) : base(combatUnit)
    {

    }

    public override void Enter()
    {
        Debug.Log("Combat Unit Entered Idle State");
    }
    public override void Update()
    {
        combatUnit.FindTarget();

        if (combatUnit.CurrentTarget != null)
        {
            combatUnit.ChangeState(new CombatChaseState(combatUnit));
        }
    }
}
