using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    public List<Rigidbody> Spawn(float currentChance, Transform parentTransform)
    {
        List<Rigidbody> spawnedBodies = new List<Rigidbody>();

        int minValue = 2;
        int maxValue = 6;
        int spawnCount = Random.Range(minValue, maxValue + 1);

        float nextChance = currentChance / 2f;
        Vector3 nextScale = parentTransform.localScale / 2f;

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject newCube = Instantiate(_prefab, parentTransform.position, parentTransform.rotation);
            Cube cubeScript = newCube.GetComponent<Cube>();

            if (cubeScript != null)
            {
                cubeScript.Init(nextChance, nextScale);
                Rigidbody rb = newCube.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    spawnedBodies.Add(rb);
                }
            }
        }

        return spawnedBodies;
    }
}