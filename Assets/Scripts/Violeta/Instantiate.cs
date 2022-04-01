using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Instantiate : MonoBehaviour
{
    public GameObject bic1;
    public GameObject bic2;

    public int numBichos = 6;

    [SerializeField]
    private float secInstantiate = 2.0f;

    private Vector3 center = Vector3.zero;
    
    //añadir un array de vectores y que elija 1 al azar
    //poner un contador que instancie cada segundo

    private void Start()
    {
        numBichos = 6;
    }

    private void Update()
    {       secInstantiate -= Time.deltaTime;
            float ang = Random.value * 360;

            if (secInstantiate <= 0f && numBichos>0)
            {
                Vector3 pos = RandomCircle(center, 12.5f, ang);
                Instantiate(bic1, pos, Quaternion.identity);
                Instantiate(bic2, pos, Quaternion.identity);
                secInstantiate = 2f;
                numBichos--;
            }    
    }
    Vector3 RandomCircle(Vector3 center, float radius, float ang)
    {
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}


