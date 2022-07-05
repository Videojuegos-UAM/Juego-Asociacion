using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoPutrido : MonoBehaviour
{
    /*[SerializeField] //privada que se ve en el inspector, las variables deberían ser lo menos públicas posibles
    private Transform transformation; //podría haber declarado directamente el position, no hacía falta la variable*/

    public Transform centre;
    public Rosa laflor;
    float seconds = 0f;

    public int health; 
    public float speed;
    public int destroy;

    // Start is called before the first frame update
    void Start()
    {
        laflor = GameObject.Find("laFlor").GetComponent<Rosa>();
        Quaternion rotation = Quaternion.LookRotation
            (Vector3.zero - transform.position, transform.TransformDirection(Vector3.back));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        //transform.Rotate(0, 0, 90); //rota 90 grados en z

        centre.transform.position = new Vector3(0, 0, 0);
        health = 2; //lo mejor es ponerlos en el inspector
        speed = 6f;
        destroy = 0;
    }

    // Update is called once per frame

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rosa"))
        {
            
            if (seconds <= 0)
            {
                seconds++;
                laflor.RosaReduceHealth();
            }
            
        }
    }

    private void OnDestroy()
    {
        laflor.muertos++;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, centre.transform.position, speed*Time.deltaTime);
        seconds -= Time.deltaTime;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

}
