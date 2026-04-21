using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingCube : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private List<Rigidbody> _spawnedBodies = new List<Rigidbody>();
    private float _cloneChance = 1.0f;

    public void Init(float chance, Vector3 scale)
    {
        _cloneChance = chance;
        transform.localScale = scale;
    }

    private void OnMouseUpAsButton()
    {
        if (Random.value <= _cloneChance)
        {
            CloneCubes();
            Explode();
        }
        
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach (Rigidbody rb in _spawnedBodies)
        {
            rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private void CloneCubes()
    {
        int minValue = 2;
        int maxValue = 6;
        int spawnCount = Random.Range(minValue, maxValue + 1);
        float nextChance = _cloneChance / 2f;
        Vector3 nextScale = transform.localScale / 2f;

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject newCube = Instantiate(_prefab, transform.position, transform.rotation);
            ExplodingCube cubeScript = newCube.GetComponent<ExplodingCube>();

            if (cubeScript != null)
            {
                cubeScript.Init(nextChance, nextScale);
                
                Rigidbody rb = newCube.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    _spawnedBodies.Add(rb);
                }
            }
        }
    }
}