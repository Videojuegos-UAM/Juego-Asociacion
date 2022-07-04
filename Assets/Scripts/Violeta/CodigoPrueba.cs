using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoPrueba : MonoBehaviour
{
    public Transform transforming;
    public float xVar, yVar, xMod = -0.01f, yMod = -0.01f;
   

    // Start is called before the first frame update
    void Start()
    {
        transforming.position = new Vector3(10, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {  
        if (xVar == 0)
        {
            xMod = 0;
        }

        transforming.position = new Vector3(xVar, yVar, 0);
        xVar = transform.position.x -0.01f;
        yVar = transform.position.y - 0.01f;

        
    }
}
