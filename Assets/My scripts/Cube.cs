using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action<Cube> Clicked;

    public float CloneChance { get; private set; } = 1.0f;

    public void Init(float chance, Vector3 scale)
    {
        CloneChance = chance;
        transform.localScale = scale;
    }

    private void OnMouseUpAsButton()
    {
        Clicked.Invoke(this);
    }
}