using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputProcessor : MonoBehaviour
{
    public static bool IsMouseButtonPressed() => Input.GetMouseButton(0);
}
