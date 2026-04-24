using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputProcessor : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private void OnMouseUpAsButton()
    {
        _cube.ProcessClick();
    }
}
