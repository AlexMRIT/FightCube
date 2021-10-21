using UnityEngine;

public sealed class TimeDamage
{
    private readonly float AttackSpeed;
    private float AttackTime;

    public TimeDamage(float attackSpeed)
    {
        AttackSpeed = attackSpeed;
        AttackTime = 0;
    }

    public bool DamageCanDone()
    {
        AttackTime -= Time.deltaTime;

        if (LessOrEqualVariableZero(AttackTime))
        {
            AttackTime = AttackSpeed;
            return true;
        }

        return false;
    }

    private bool LessOrEqualVariableZero(float value)
    {
        return value <= 0;
    }
}