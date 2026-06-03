public abstract class CombatState
{
    protected CombatUnitController combatUnit;

    public CombatState(CombatUnitController combatUnit)
    {
        this.combatUnit = combatUnit;
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
