using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public CodigoBicho bic1;
    public CodigoPutrido bic2;
    void Start()
    {
        for(int i = 0; i<bic1.totalBichos; i++)
        {
            if(i <= bic1.totalBichos / 2)
            {
                Instantiate(bic1, new Vector3(12 + i, 12 + i, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(bic1, new Vector3(-12+(i+bic1.totalBichos), -12 + (i + bic1.totalBichos), 0), Quaternion.identity);
            }
        }

        for (int i = 0; i < bic1.totalBichos; i++)
        {
            if (i <= bic1.totalBichos / 2)
            {
                Instantiate(bic1, new Vector3(6, 12 + i, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(bic1, new Vector3(-6, -12 + (i + bic2.totalBichos), 0), Quaternion.identity);
            }
        }
    }

}
