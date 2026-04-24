using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private Detonator _exploder;

    private float _cloneChance = 1.0f;

    public void Init(float chance, Vector3 scale)
    {
        _cloneChance = chance;
        transform.localScale = scale;
    }

    public void ProcessClick()
    {
        if (Random.value <= _cloneChance)
        {
            var spawnedBodies = _spawner.Spawn(_cloneChance, transform);
            _exploder.ApplyForce(spawnedBodies, transform.position);
        }

        Destroy(gameObject);
    }
}