using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFunction : MonoBehaviour
{
    public CodigoBicho bicho;
    public int dead = 0;

    private void OnMouseDown()
    {
        dead++;
        bicho.health--;
    }
}
