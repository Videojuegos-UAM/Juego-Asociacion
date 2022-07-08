using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    [SerializeField]private float regularValue;
    [SerializeField]private float speed;
    [SerializeField]private float modifier;
    private float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime*speed;
        float actualValue;
        actualValue = regularValue + modifier*Mathf.Sin(timer);
        transform.localScale = new Vector3(actualValue,actualValue, 1);
    }
}
