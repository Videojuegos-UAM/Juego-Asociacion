using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoBicho : MonoBehaviour
{

    public Transform centre;
    public Rosa laflor;
    //collider.getcomponent(coger la rosa).
    public int health;
    public float speed;
    float seconds = 0f;
    public int destroy;

    // Start is called before the first frame update
    void Start()
    {
        laflor = GameObject.Find("laFlor").GetComponent<Rosa>();
        Quaternion rotation = Quaternion.LookRotation(Vector3.zero - transform.position, transform.TransformDirection(Vector3.back));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        //transform.Rotate(0, 0, 90); //rota 90 grados en z

        centre.transform.position = new Vector3(0, 0, 0);
        health = 2; //lo mejor es ponerlos en el inspector
        speed = 4f;
        destroy = 0;
    }
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

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, centre.transform.position, speed * Time.deltaTime);
        seconds -= Time.deltaTime;
        if (health == 0)
        {
            Destroy(gameObject);
            destroy++;
        }

    }

    private void OnDestroy()
    {
        laflor.muertos++;
    }

    /*private void OnDestroy()
    {
        /*salud.bicho--;*/
    /*llamar texto*/
    //}
}
