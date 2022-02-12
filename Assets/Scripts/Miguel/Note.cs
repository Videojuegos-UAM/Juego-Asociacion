using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NoteDirection{
    LEFT, RIGHT, UP, DOWN
}
public enum NoteType{
    SHORT, LONG
}

public class Note : MonoBehaviour{
    [SerializeField] private Disk disk;
    [SerializeField] private CameraShake cam;
    [SerializeField] NoteDirection direction;
    [SerializeField] NoteType type;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite shineSprite;
    [SerializeField] float timer_max = 0.1f;
    private bool onTrigger;
    private bool cleared;
    private SpriteRenderer spriteRenderer;
    private KeyCode activator;
    private float timer;

    void Start(){
        disk = GameObject.Find("Disk").GetComponent<Disk>();
        cam = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;
        timer_max = 0.1f;
    }

    private void Awake(){
        onTrigger = false;
        cleared = false;

        if(this.direction == NoteDirection.LEFT){
            this.transform.position = new Vector3(4.25f, 0, 0);
            this.transform.Rotate(new Vector3(0, 0, 180));
            this.activator = KeyCode.LeftArrow;
        }
        if(this.direction == NoteDirection.UP){
            this.transform.position = new Vector3(3.25f, 0, 0);
            this.transform.Rotate(new Vector3(0, 0, 90));
            this.activator = KeyCode.UpArrow;
        }
        if(this.direction == NoteDirection.DOWN){
            this.transform.position = new Vector3(2.25f, 0, 0);
            this.transform.Rotate(new Vector3(0, 0, -90));
            this.activator = KeyCode.DownArrow;
        }
        if(this.direction == NoteDirection.RIGHT){
            this.transform.position = new Vector3(1.25f, 0, 0);
            this.transform.Rotate(new Vector3(0, 0, 0));
            this.activator = KeyCode.RightArrow;
        }
    }
    
    void Update(){
        if(cleared == false){
            this.transform.RotateAround(new Vector3(0, 0, 0), Vector3.back, disk.speed*Time.deltaTime);
            if (Input.GetKeyDown(activator) && onTrigger == true){
                cleared = true;
                disk.success++;
                timer = timer_max;
                spriteRenderer.sprite = shineSprite;
                if(this.direction == NoteDirection.LEFT){
                    this.transform.position = new Vector3(-4.25f, 0, 0);
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                if(this.direction == NoteDirection.UP){
                    this.transform.position = new Vector3(-3.25f, 0, 0);
                    this.transform.rotation = Quaternion.Euler(0, 0, -90);
                }
                if(this.direction == NoteDirection.DOWN){
                    this.transform.position = new Vector3(-2.25f, 0, 0);
                    this.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
                if(this.direction == NoteDirection.RIGHT){
                    this.transform.position = new Vector3(-1.25f, 0, 0);
                    this.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
        }
        if(cleared == true){
           timer -= Time.deltaTime;
           if (timer <= 0){
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        onTrigger = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision){
        if (cleared == false){
            Destroy(gameObject);
            cam.TriggerShake();
            disk.GetComponent<Disk>().fail++;
        }
    }
}
