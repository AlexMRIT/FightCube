public struct Damage
{
    public Damage(float damage)
        : this(damage, DamageCountDefault) { }

    public Damage(float damage, float damageCount)
    {
        DamageStength = damage;
        DamageCount = damageCount;
    }

    public float DamageStength { get; set; }
    public float DamageCount { get; set; }

    private const int DamageCountDefault = 1;
}