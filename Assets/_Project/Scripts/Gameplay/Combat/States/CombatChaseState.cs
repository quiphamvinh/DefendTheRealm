using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatChaseState : CombatState
{
    public CombatChaseState(CombatUnitController combatUnit) : base(combatUnit)
    {

    }

    public override void Enter()
    {
        Debug.Log("Combat Unit Entered Chase State");
    }

    public override void Update()
    {
        if (combatUnit.CurrentTarget == null)
        {
            combatUnit.ChangeState(new CombatIdleState(combatUnit));
            return;
        }
        combatUnit.MoveToTarget();

        float distance = Vector3.Distance(combatUnit.transform.position, combatUnit.CurrentTarget.transform.position);

        if (distance <= combatUnit.AttackRange)
        {
            combatUnit.ChangeState(new CombatAttackState(combatUnit));
        }
    }
}
