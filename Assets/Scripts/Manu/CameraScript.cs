using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform follow;
    [SerializeField] bool follow_x;
    [SerializeField] bool follow_y;
    [SerializeField] bool follow_z;

    // Update is called once per frame
    void Update()
    {
        if (follow_x)
        {
            transform.position = new Vector3(follow.position.x,transform.position.y,transform.position.z);
        }
        if (follow_y)
        {
            transform.position = new Vector3(transform.position.x, follow.position.y, transform.position.z);
        }
        if (follow_z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, follow.position.z);
        }
    }
}
