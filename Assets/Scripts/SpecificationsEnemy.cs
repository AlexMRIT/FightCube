using static SpecificationsEnemy.SpecificationsDefault;

internal sealed class SpecificationsEnemy
{
    public SpecificationsEnemy(float health, int countAttack) 
        : this(health, GetMoveSpeedDefault, GetAttackDistanceDefault, GetAgressiveDistatanceDefault, 
        GetForceImpulseDefault, GetDamageDefault, GetAttackSpeedDefault, countAttack) { }

    public SpecificationsEnemy(float health, float moveSpeed, float damage)
        : this(health, moveSpeed, GetAgressiveDistatanceDefault, GetAgressiveDistatanceDefault,
              GetForceImpulseDefault, GetDamageDefault, GetAttackSpeedDefault, GetAttackCountDefault) { }

    public SpecificationsEnemy(float health, float moveSpeed, float attackDistance,
        float agressiveDistance, float forceImpulse, float damage, float attackSpeed, int attackCount)
    {
        Health = health;
        MoveSpeed = moveSpeed;
        AttackDistance = attackDistance;
        AgressiveDistance = agressiveDistance;
        ForceImpulse = forceImpulse;
        Damage = damage;
        AttackSpeed = attackSpeed;
        AttackCount = attackCount;
    }

    public float Health { get; set; }
    public float MoveSpeed { get; set; }
    public float AttackDistance { get; set; }
    public float AgressiveDistance { get; set; }
    public float ForceImpulse { get; set; }
    public float Damage { get; set; }
    public float AttackSpeed { get; set; }
    public int AttackCount { get; set; }

    internal static class SpecificationsDefault
    {
        public static readonly float GetHealthDefault = 100F;
        public static readonly float GetMoveSpeedDefault = 5F;
        public static readonly float GetAttackDistanceDefault = 1.1F;
        public static readonly float GetAgressiveDistatanceDefault = 50F;
        public static readonly float GetForceImpulseDefault = 15F;
        public static readonly float GetDamageDefault = 5F;
        public static readonly float GetAttackSpeedDefault = 1F;
        public static readonly int GetAttackCountDefault = 1;
    }
}