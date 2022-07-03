using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Instantiate : MonoBehaviour
{
    public GameObject bic1;
    public GameObject bic2;
    public GameOver gover;

    public int numBichos;
    public int muertos;

    [SerializeField]
    private float secInstantiate = 2.0f;
    public float timerVictory = 0f;

    public Rosa rosa;

    private Vector3 center = Vector3.zero;
    
    //añadir un array de vectores y que elija 1 al azar
    //poner un contador que instancie cada segundo

    private void Start()
    {
        numBichos = 12;
        muertos = 0;
        timerVictory = numBichos * 2;
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
                numBichos -= 2;
            }

        timerVictory -= Time.deltaTime;
        if (timerVictory <= 0 && rosa.health > 0)
        {
            gover.Setup();
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


