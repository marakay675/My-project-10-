using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _explosionForce = 500f;
    private float _explosionRadius = 5f;

    public void Explode(Vector3 position, float currentScale)
    {
        float dynamicForce = _explosionForce / currentScale;
        float dynamicRadius = _explosionRadius / currentScale;

        Collider[] overlappedColliders = Physics.OverlapSphere(position, dynamicRadius);

        List<Rigidbody> rigidbodies = new List<Rigidbody>();

        foreach (Collider overlappedCollider in overlappedColliders)
        {
            if (overlappedCollider.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbodies.Add(rigidbody);
            }
        }

        ApplyForce(rigidbodies, position, dynamicForce, dynamicRadius);

        if (transform.position == position)
        {
            Destroy(gameObject);
        }
    }

    public void ApplyForce(List<Rigidbody> targets, Vector3 position, float dynemicForce, float dynemicRadius)
    {
        foreach (Rigidbody rb in targets)
        {
            rb.AddExplosionForce(_explosionForce, position, _explosionRadius);
        }
    }
}
