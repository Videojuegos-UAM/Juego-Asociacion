using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disk : MonoBehaviour{

    [SerializeField] public float speed;
    public GameObject NoteLeft;
    public GameObject NoteUp;
    public GameObject NoteDown;
    public GameObject NoteRight;
    public float timer_max;
    private float timer = 0;
    public int success = 0;
    public int fail = 0;
    private int counter = 0;
    public Text score;

    // Start is called before the first frame update
    void Start(){
        this.transform.position = new Vector3(0, 0, 0);
        this.success = 0;
        this.fail = 0;
        score = GameObject.Find("score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update(){
        this.transform.Rotate(new Vector3(0, 0, -50 * Time.deltaTime));
        timer -= Time.deltaTime;
        if(timer <= 0){
           int i = Random.Range(0, 4);
           if(i<1)          Instantiate(NoteLeft);
           else if (i<2)    Instantiate(NoteUp);
           else if (i < 3)  Instantiate(NoteDown);
           else if (i < 4)  Instantiate(NoteRight);
           timer = timer_max;
           counter++;
        }
        score.text = "Aciertos: " + success + "\nFallos: " + fail;
    }
}
