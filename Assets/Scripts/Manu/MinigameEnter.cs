using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameEnter : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject image;

    private bool isPlayerInPlace = false;
    // Start is called before the first frame update
    void Awake()
    {
        image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerInPlace)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            image.SetActive(true);
            isPlayerInPlace = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            image.SetActive(false);
            isPlayerInPlace = false;
        }
    }
}
