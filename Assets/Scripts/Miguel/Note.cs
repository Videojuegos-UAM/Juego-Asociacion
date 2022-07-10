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
    public TrailRenderer trail;
    private bool onTrigger;
    private bool cleared;
    private SpriteRenderer spriteRenderer;
    private KeyCode activator;
    private float timer;

    void Start(){
        disk = GameObject.Find("Disk").GetComponent<Disk>();
        cam = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        trail = gameObject.GetComponent<TrailRenderer>();
        spriteRenderer.sprite = defaultSprite;
        timer_max = 0.1f;
    }

    private void Awake(){
        onTrigger = false;
        cleared = false;
        
        int i = Random.Range(0, 2);
        if(i<1) type = NoteType.SHORT;
        else if(i<2) type = NoteType.LONG;

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
        if(this.type == NoteType.SHORT){
            this.trail.enabled = false;
        }
        if(this.type == NoteType.LONG){
            this.trail.enabled = true;
        }
    }
    
    void Update(){
        if(cleared == false){
            this.transform.RotateAround(new Vector3(0, 0, 0), Vector3.back, disk.speed*Time.deltaTime);

            if (Input.GetKeyDown(activator) && this.onTrigger == true){
                this.spriteRenderer.sprite = shineSprite;
                // Locate to trigger
                if(this.direction == NoteDirection.LEFT){
                    this.spriteRenderer.color = new Color(1f, 0.5f, 0.5f,1);
                    this.transform.position = new Vector3(-4.25f, 0, 0);
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                if(this.direction == NoteDirection.UP){
                    this.spriteRenderer.color = new Color(1f, 1f, 0.7f,1);
                    this.transform.position = new Vector3(-3.25f, 0, 0);
                    this.transform.rotation = Quaternion.Euler(0, 0, -90);
                }
                if(this.direction == NoteDirection.DOWN){
                    this.spriteRenderer.color = new Color(0.6f, 1f, 1f,1);
                    this.transform.position = new Vector3(-2.25f, 0, 0);
                    this.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
                if(this.direction == NoteDirection.RIGHT){
                    this.spriteRenderer.color = new Color(0.65f, 1f, 0.6f,1);
                    this.transform.position = new Vector3(-1.25f, 0, 0);
                    this.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
                disk.successNote();
                this.cleared = true;
                if(this.type == NoteType.SHORT){
                    this.timer = timer_max;
                }
                else{
                    this.timer = timer_max*8;
                }
            }
        }
        
        if(this.cleared == true){
           if (this.timer <= 0){
                if (this.type == NoteType.LONG){
                    disk.success += 3;
                }
               Destroy(gameObject);
           }
           this.timer -= Time.deltaTime;
           if(this.type == NoteType.LONG && !Input.GetKey(activator)){
                 Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        this.onTrigger = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision){
        if (this.cleared == false){
            Destroy(gameObject);
            cam.TriggerShake();
            disk.failure();
        }
    }
}
