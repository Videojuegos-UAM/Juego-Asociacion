using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFunction : MonoBehaviour
{
    public CodigoBicho bicho;

    private void OnMouseDown()
    {
        bicho.health--;
    }
}
