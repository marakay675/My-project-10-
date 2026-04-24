using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void ApplyForce(List<Rigidbody> targets, Vector3 position)
    {
        foreach (Rigidbody rb in targets)
        {
            rb.AddExplosionForce(_explosionForce, position, _explosionRadius);
        }
    }
}
