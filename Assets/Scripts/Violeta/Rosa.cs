using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rosa : MonoBehaviour
{
    public float seconds;
    public int health;
    public int muertos;
    public GameOver gover;
    private void Start()
    {
        seconds = 0;
        health = 30;
        muertos = 0;
    }

    //hacer un cronómetro de cuanto tiempo lleva, y bajarle deltatime cada x segundos.
    //poner el ontriggerstay2d en los enemigos, y que a través del collider le baje la vid a la rosa. Hacer función en rosa que le baje la vida
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Insecto")
        {
            seconds -= Time.deltaTime;
            if(seconds <= 0)
            {
                health--;
                seconds++;
            }
            
            if(health == 0)
            {
                Destroy(gameObject);
            }
        }
    }*/

    public void RosaReduceHealth()
    {
        health--;
        if (health == 0)
        {
            Destroy(gameObject);
            gover.Setup();
        }
    }
}
