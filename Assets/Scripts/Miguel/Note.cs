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
                // Locate to trigger
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
                this.spriteRenderer.sprite = shineSprite;
                this.spriteRenderer.color = new Color(0.8f,0.8f,0.8f,1); // TODO: change to same but brighter color
                disk.success++;
                if(this.type == NoteType.SHORT){
                    this.cleared = true;
                    this.timer = timer_max; // change for long
                }
            }
        }
        if(Input.GetKey(activator) && this.onTrigger == true && this.type == NoteType.LONG){
            // Wait for trail, give more success points
            /*
                Mesh mesh = new Mesh();
                this.trail.BakeMesh(mesh);*/
        }
        
        if(this.cleared == true){
           this.timer -= Time.deltaTime;
           if (this.timer <= 0){
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
            disk.fail++;
        }
    }
}
