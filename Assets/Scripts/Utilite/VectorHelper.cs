using UnityEngine;

public static class Distance
{
    public static bool CheckDistance(Transform first, Transform second, float distance)
    {
        return Vector3.Distance(first.position, second.position) <= distance;
    }

    public static void MoveToTarget(Transform first, Transform target, float moveSpeed, float stopDistance = 1F)
    {
        if (!CheckDistance(first, target, stopDistance))
            first.position = Vector3.MoveTowards(first.position, target.position, moveSpeed * Time.deltaTime);
    }
}