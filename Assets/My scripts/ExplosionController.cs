using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private InputProcessor _input;

    private void OnEnable()
    {
        _input.CubeClicked += _exploder.Explode;
    }

    private void OnDisable()
    {
        _input.CubeClicked -= _exploder.Explode;
    }
}
