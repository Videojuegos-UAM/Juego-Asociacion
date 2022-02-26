using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoBicho : MonoBehaviour
{

    public Transform transformation; //podría haber declarado directamente el position, no hacía falta la variable

    public Transform centre;

    public int health;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        transformation.position = new Vector3(12, 12, 0);
        health = 1;
        speed = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        transformation.position = Vector3.MoveTowards(transformation.position, centre.transform.position, speed);

        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
}
