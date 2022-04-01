using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoBicho : MonoBehaviour
{

    public Transform centre;

    public int health;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        Quaternion rotation = Quaternion.LookRotation
           (Vector3.zero - transform.position, transform.TransformDirection(Vector3.back));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        //transform.Rotate(0, 0, 90); //rota 90 grados en z

        centre.transform.position = new Vector3(0, 0, 0);
        health = 2; //lo mejor es ponerlos en el inspector
        speed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, centre.transform.position, speed * Time.deltaTime);

        if (health == 0)
        {
            Destroy(gameObject);
        }

    }
}
