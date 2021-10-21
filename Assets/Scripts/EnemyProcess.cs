using UnityEngine;
using System.Collections.Generic;

#nullable enable

public sealed class EnemyProcess : MonoBehaviour
{
    private readonly Dictionary<int, EnemyComponentBase> EnemiesList = new Dictionary<int, EnemyComponentBase>();
    
    public void AddNewTarget(EnemyComponentBase enemyComponent)
    {
        enemyComponent.Id = ++enemyComponent.Id + EnemiesList.Count;
        EnemiesList.Add(enemyComponent.Id, enemyComponent);
    }

    public GameObject? NextTarget(EnemyComponentBase thisEnemy)
    {
        foreach (KeyValuePair<int, EnemyComponentBase> obj in EnemiesList)
            if (!obj.Key.Equals(thisEnemy.Id))
                return obj.Value.gameObject;

        return null;
    }

    public void DestroyEnemy(EnemyComponentBase enemyComponent)
    {
        EnemiesList.Remove(enemyComponent.Id);
    }
}