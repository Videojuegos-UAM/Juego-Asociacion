using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InsectCounter : MonoBehaviour
{
    public string textoo;

    private CodigoBicho b1;

    public int totalBichos;

    public Text texto;

    
    void Start()
    {
        totalBichos = 12; //Manera muy cutre porque ahora tengo que ahora tengo que cambiar dos cosas para variar cantidad de bichos.
    }

    void Update()
    {
        //totalBichos = 12 - b1.dead;       Si pongo esta línea sale "New Text"
        texto.text = "Quedan " + totalBichos.ToString() + " bichos verdes.";
    }
}
