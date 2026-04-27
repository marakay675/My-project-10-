using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubeController _controller;

    public List<Rigidbody> Spawn(float currentChance, Transform parentTransform)
    {
        List<Rigidbody> spawnedBodies = new List<Rigidbody>();

        float devisor = 2f;
        int minValue = 2;
        int maxValue = 6;
        int spawnCount = Random.Range(minValue, maxValue + 1);

        float nextChance = currentChance / devisor;
        Vector3 nextScale = parentTransform.localScale / devisor;

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject newCube = Instantiate(gameObject, parentTransform.position, parentTransform.rotation);
            Cube cubeScript = newCube.GetComponent<Cube>();

            if (cubeScript != null)
            {
                cubeScript.Init(nextChance, nextScale);
                _controller.RegisterCube(cubeScript);

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