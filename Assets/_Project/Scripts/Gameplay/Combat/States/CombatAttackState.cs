using UnityEngine;

public class CombatAttackState : CombatState
{
    public CombatAttackState(CombatUnitController combatUnit) : base(combatUnit)
    {

    }

    public override void Enter()
    {
        Debug.Log("Combat Unit Entered Attack State");
    }

    public override void Update()
    {
        if (combatUnit.CurrentTarget == null)
        {
            combatUnit.ChangeState(new CombatIdleState(combatUnit));
            return;
        }

        float distance = Vector3.Distance(combatUnit.transform.position, combatUnit.CurrentTarget.transform.position);

        if (distance > combatUnit.AttackRange)
        {
            combatUnit.ChangeState(new CombatChaseState(combatUnit));
            return;
        }

        combatUnit.Attack();
    }
}