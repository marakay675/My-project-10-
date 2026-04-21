using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorConverter : MonoBehaviour
{
    private void Start()
    {
        SetNewColor();
    }

    public void SetNewColor()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();

        renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
