using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aguja: MonoBehaviour{
    public float timer_max;
    private float timer = 0;

    void Start(){
        this.timer = 0;
    }

    void Update(){
        timer -= Time.deltaTime;
        if (timer <= 0){
            int i = Random.Range(0, 3);
            if (i < 1) this.transform.rotation = Quaternion.Euler(0,0,15);
            else if (i < 2) this.transform.rotation = Quaternion.Euler(0, 0, 30);
            else if (i < 3) this.transform.rotation = Quaternion.Euler(0, 0, 35);
            timer = timer_max+Random.Range(0,4);
        }
    }
}
