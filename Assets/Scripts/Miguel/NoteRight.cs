using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRight : MonoBehaviour {

    private bool onTrigger;
    private bool cleared;
    public GameObject Disk;

    // Start is called before the first frame update
    void Start(){
        this.transform.position = new Vector3(1.25f, 0, 0);
        this.transform.Rotate(new Vector3(0, 0, 0));
        onTrigger = false;
        cleared = false;
        Disk = GameObject.Find("Disk");
    }

    // Update is called once per frame
    void Update(){
        this.transform.RotateAround(new Vector3(0, 0, 0), Vector3.back, 50 * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.RightArrow) && onTrigger == true){
            cleared = true;
            Destroy(gameObject);
            Disk.GetComponent<Disk>().success++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        onTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(cleared == false){
            Destroy(gameObject);
            Disk.GetComponent<Disk>().fail++;
        }
    }
}