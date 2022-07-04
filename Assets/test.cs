using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private AudioClip audios;
    void Start()
    {
        SoundEmitter.Instance().PlayMusic(audios);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
