using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rosa : MonoBehaviour
{
    public int health;
    void Start()
    {
        health = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }    
    }
      /*  void onTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag = "Insecto")
        {
            new WaitForSeconds(1);
            health--;
        }
    }*/
}
