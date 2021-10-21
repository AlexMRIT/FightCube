using System;

internal sealed class EnemyStats
{
    public EnemyStats(SpecificationsEnemy pSpecificationsStruct)
    {
        if (pSpecificationsStruct is null)
            throw new ArgumentNullException(nameof(SpecificationsEnemy));

        Specifications = pSpecificationsStruct;
    }

    public SpecificationsEnemy Specifications { get; private set; }

    public ResultChange OperationChangeHealth(float value, Operation operation)
    {
        return operation switch
        {
            Operation.Add => ValidIsLessOrAboveZero.ValidValue(Specifications.Health += value),
            Operation.Decrease => ValidIsLessOrAboveZero.ValidValue(Specifications.Health -= value),
            _ => ResultChange.EqualZero,
        };
    }
}

internal static class ValidIsLessOrAboveZero
{
    public static ResultChange ValidValue(float value)
    {
        if (value < 0) return ResultChange.LessZero;
        else if (value == 0) return ResultChange.EqualZero;

        return ResultChange.AboveZero;
    }
}