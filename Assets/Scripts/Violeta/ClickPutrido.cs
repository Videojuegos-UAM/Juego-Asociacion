using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPutrido : MonoBehaviour
{
    public CodigoPutrido bicho;

    private void OnMouseDown()
    {
        bicho.health--;
        bicho.speed /= 2;
    }
}