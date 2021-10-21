using UnityEngine;

public sealed class PhysicsRigidBody
{
    public PhysicsRigidBody(Rigidbody rigidbody)
    {
        RigidbodyComponent = rigidbody;
    }

    private readonly Rigidbody RigidbodyComponent;

    public void AddForce(GameObject first, GameObject second, float pushForce)
    {
        RigidbodyComponent.AddForce((first.transform.position - second.transform.position).normalized * pushForce, ForceMode.Impulse);
    }
}