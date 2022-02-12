using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour{
    [SerializeField] private float shakeMagnitude = 0.3f;
    private float shakeDuration;
    private Vector3 initialPosition;

    void Start(){
        initialPosition = transform.localPosition;
        shakeDuration = 0f;
    }

    // Update is called once per frame
    void Update(){
        if (shakeDuration > 0){
            this.transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime;
        }
        else{
            this.transform.localPosition = initialPosition;
            shakeDuration = 0f;
        }
    }

    public void TriggerShake(){
        shakeDuration = 0.01f;
    }
}
