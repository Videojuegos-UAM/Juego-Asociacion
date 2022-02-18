using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPot : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _leftTreshold;
    [SerializeField] private float _rightTreshold;
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
        {
            transform.Translate(-_speed*Time.deltaTime, 0, 0);
            if (transform.position.x <= _leftTreshold)
            {
                transform.position = new Vector3(_rightTreshold, transform.position.y, transform.position.x);
            }
        }
        if(Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed*Time.deltaTime, 0, 0);
            if (transform.position.x >= _rightTreshold)
            {
                transform.position = new Vector3(_leftTreshold, transform.position.y, transform.position.x);
            }
        }
    }
}
