using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoPutrido : MonoBehaviour
{
    public Transform transformation; //podría haber declarado directamente el position, no hacía falta la variable

    public Transform centre;

    public int health;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        transformation.position = new Vector3(-4, 12, 0);
        health = 2;
        speed = 0.006f;
    }

    // Update is called once per frame
    void Update()
    {
        transformation.position = Vector3.MoveTowards(transformation.position, centre.transform.position, speed);

        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
