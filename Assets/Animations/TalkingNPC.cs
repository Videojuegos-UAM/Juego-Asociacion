using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingNPC : MonoBehaviour
{
    [SerializeField] private Text talk;
    [SerializeField] private Image image;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject trigger;
    [Header("Sprites")]
    [SerializeField] private Sprite exclamationMark;
    [SerializeField] private Sprite message;

    private void Awake()
    {
        image.sprite = exclamationMark;
        talk.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            image.sprite = message;
            talk.gameObject.SetActive(true);
            animator.SetBool("Talking",true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            image.sprite = exclamationMark;
            talk.gameObject.SetActive(false);
            animator.SetBool("Talking", false);
        }
    }
}
