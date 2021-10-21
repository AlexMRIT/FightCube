using System;
using UnityEngine;

public sealed class TargetEnemy : IDisposable
{
    public TargetEnemy() { }

    public TargetEnemy(GameObject target)
    {
        Target = target;

        if (target.TryGetComponent(out EnemyComponentBase targetComponent))
            ComponentTarget = targetComponent;
        else
            throw new ArgumentException(nameof(EnemyComponentBase));
    }

    public GameObject Target { get; private set; }
    public EnemyComponentBase ComponentTarget { get; private set; }

    public void Dispose()
    {
        Target = null;
        ComponentTarget = null;
    }
}