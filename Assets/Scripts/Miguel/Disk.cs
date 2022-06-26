using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disk : MonoBehaviour{
    [SerializeField] private GameObject noteLeft;
    [SerializeField] private GameObject noteUp;
    [SerializeField] private GameObject noteDown;
    [SerializeField] private GameObject noteRight;
    [SerializeField] public float speed;
    [SerializeField] private float timer_max;
    [SerializeField] private AudioSource Disk1Audio;

    public int success;
    private float timer;

    private void Awake(){
        this.transform.position = new Vector3(0, 0, 0);
        this.success = 0;
        this.timer = 0;
        Disk1Audio.Play();
    }

    public void failure()
    {
        this.success--;
        this.transform.Rotate(new Vector3(0, 0, speed * 0.3f));
    }

    void Start(){
    }

    void Update(){
        this.transform.Rotate(new Vector3(0, 0, -speed * Time.deltaTime));

        timer -= Time.deltaTime;
        if(timer <= 0){
           int i = Random.Range(0, 4);
           if(i<1)          Instantiate(noteLeft);
           else if (i<2)    Instantiate(noteUp);
           else if (i < 3)  Instantiate(noteDown);
           else if (i < 4)  Instantiate(noteRight);
           timer = timer_max;
        }

        if (!Disk1Audio.isPlaying)
        {
            Application.Quit();
        }
  
    }
}
