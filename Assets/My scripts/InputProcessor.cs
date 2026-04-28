using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputProcessor : MonoBehaviour
{
    public static event Action<Vector3, float> OnCubeClicked;

    private void OnMouseUpAsButton()
    {
        OnCubeClicked?.Invoke(transform.position, transform.localScale.x);
    }
}
