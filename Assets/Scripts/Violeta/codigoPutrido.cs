using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoPutrido : MonoBehaviour
{
    public CodigoBicho putridoInsecto;

    // Start is called before the first frame update
    void Start()
    {
        putridoInsecto.transformation.position = new Vector3(-12, 4, 0);
        putridoInsecto.health = 2;
        putridoInsecto.speed = 0.0075f;
    }

    // Update is called once per frame
    void Update()
    {
        putridoInsecto.transformation.position = Vector3.MoveTowards(putridoInsecto.transformation.position, putridoInsecto.centre.transform.position, putridoInsecto.speed);
        if (putridoInsecto.health == 0)
        {
            Destroy(gameObject);
        }
    }
}
