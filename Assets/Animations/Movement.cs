using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float velocity = 3f;
    private float previousz;
    [Header("Limites")]
    [SerializeField] private Transform LimiteDerecha;
    [SerializeField] private Transform LimiteIzquierda;
    // Update is called once per frame
    void Update()
    {
        float z= Input.GetAxis("Vertical");
        if((z>0&&previousz<0)||(previousz > 0 && z < 0))
        {
            transform.Rotate(new Vector3(0,180,0));
        }
        animator.SetFloat("Velocity",z);
        if (z > 0)
        {
            if (transform.position.z > LimiteIzquierda.position.z)
            {
                transform.Translate(new Vector3(0, 0, Mathf.Abs(z * velocity * Time.deltaTime)));
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, LimiteIzquierda.position.z);
            }
        }
        else
        {
            if (transform.position.z < LimiteDerecha.position.z)
            {
                transform.Translate(new Vector3(0, 0, Mathf.Abs(z * velocity * Time.deltaTime)));
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, LimiteDerecha.position.z);
            }
        }
       
        if (z != 0)
        {
            previousz = z;
        }
    }
}
