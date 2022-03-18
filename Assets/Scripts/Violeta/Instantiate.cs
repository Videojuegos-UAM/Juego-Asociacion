using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Instantiate : MonoBehaviour
{
    public GameObject bic1;
    public GameObject bic2;

    [SerializeField] 
    private int numBichos = 6;

    [SerializeField]
    private float secInstantiate = 2.0f;

    private Vector3 center;

    //añadir un array de vectores y que elija 1 al azar
    //poner un contador que instancie cada segundo

    private void Update()
    {
        for (int i = 0; i < numBichos; i++) {
            secInstantiate -= Time.deltaTime;
            float ang = Random.value * 360;

            if (secInstantiate <= 0f)
            {
                Vector3 pos = RandomCircle(center, 12.5f, ang);
                Instantiate(bic1, pos, Quaternion.LookRotation(center));
                Instantiate(bic2, pos, Quaternion.LookRotation(center));
                secInstantiate = 2f;
            }    
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


