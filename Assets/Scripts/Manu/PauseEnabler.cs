using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEnabler : MonoBehaviour
{

    private GameObject _pauseMenu;
    private PauseMenu _script;
    // Start is called before the first frame update
    void Awake()
    {
        _pauseMenu= Resources.Load("PauseMenu") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CheckPauseMenu();
            _script.Pause();
        }
    }
    private void CheckPauseMenu ()
    {
        if (GameObject.Find("PauseMenu(Clone)") == null)
        {
             _script= Instantiate(_pauseMenu).GetComponent<PauseMenu>();
        }
    }

}
