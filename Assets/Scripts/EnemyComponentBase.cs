using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyComponentBase : MonoBehaviour
{
    [NonSerialized] public int Id = 0;

    private TargetEnemy Enemy;
    private EnemyStats Stats;
    private TimeDamage TimeDamageMath;
    private Damage DamageEnemy;
    private PhysicsRigidBody PhysicsRigBodyComponent;
    private EnemyProcess EnemyProcessComponent;

    private event Action OnAttack;
    private event Action OnDeath;

    [SerializeField] private float Health = 100F;
    [SerializeField] private int AttackCount = 1;

    private void OnEnable()
    {
        EnemyProcessComponent = FindObjectOfType<EnemyProcess>();
        EnemyProcessComponent.AddNewTarget(this);
    }

    private void Start()
    {
        SpecificationsEnemy specifications = new SpecificationsEnemy(Health, AttackCount);
        Stats = new EnemyStats(specifications);
        Enemy = new TargetEnemy();

        TimeDamageMath = new TimeDamage(specifications.AttackSpeed);
        DamageEnemy = new Damage(specifications.Damage, specifications.AttackCount);
        PhysicsRigBodyComponent = new PhysicsRigidBody(gameObject.GetComponent<Rigidbody>());

        OnAttack += OnAttackHandler;
        OnDeath += OnDeathHandler;

        NextTarget();
    }

    private void Update()
    {
        if (Enemy is null)
            return;

        if (Distance.CheckDistance(gameObject.transform, Enemy.Target.transform, Stats.Specifications.AgressiveDistance))
        {
            Distance.MoveToTarget(gameObject.transform, Enemy.Target.transform,
                Stats.Specifications.MoveSpeed, Stats.Specifications.AttackDistance);
        }
        
        if (Distance.CheckDistance(gameObject.transform, Enemy.Target.transform, Stats.Specifications.AttackDistance))
        {
            if (!TimeDamageMath.DamageCanDone())
                return;

            Enemy.ComponentTarget.OnAttack?.Invoke();
            Enemy.ComponentTarget.TakeDamage(DamageEnemy);
        }
    }

    public virtual void NextTarget()
    {
        SetTarget(EnemyProcessComponent.NextTarget(this));
    }

    public virtual void TakeDamage(Damage? damage)
    {
        switch(Stats.OperationChangeHealth(damage.Value.DamageStength * damage.Value.DamageCount, Operation.Decrease))
        {
            case ResultChange.LessZero:
            case ResultChange.EqualZero:
                OnDeath?.Invoke();
                break;
            case ResultChange.AboveZero: break;
        }
    }

    public virtual void SetTarget(GameObject target)
    {
        if (target is null)
            return;

        Enemy = new TargetEnemy(target);
    }

    public void ClearCurrentTarget()
    {
        Enemy.Dispose();
        Enemy = null;
    }

    public void SpawnEnemy()
    {
        EnemyProcessComponent.AddNewTarget(this);
        NextTarget();
    }

    private void OnDeathHandler()
    {
        EnemyProcessComponent.DestroyEnemy(this);
        Enemy.ComponentTarget.ClearCurrentTarget();
        Enemy.ComponentTarget.NextTarget();
        ClearCurrentTarget();
        Destroy(gameObject);
    }

    private void OnAttackHandler()
    {
        PhysicsRigBodyComponent.AddForce(gameObject, Enemy.Target, Stats.Specifications.ForceImpulse);
    }

    private void OnDisable()
    {
        OnAttack -= OnAttackHandler;
        OnDeath -= OnDeathHandler;
    }

    private void OnDestroy()
    {
        OnAttack -= OnAttackHandler;
        OnDeath -= OnDeathHandler;
    }
}