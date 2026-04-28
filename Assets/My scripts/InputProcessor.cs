using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputProcessor : MonoBehaviour
{
    public event Action<Vector3, float> CubeClicked;

    private void OnMouseUpAsButton()
    {
        CubeClicked?.Invoke(transform.position, transform.localScale.x);
    }
}
