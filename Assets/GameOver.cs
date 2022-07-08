 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneLoader.Load(SceneLoader.Scene.Violeta);
    }

    public void MainMenu()
    {
        SceneLoader.Load(SceneLoader.Scene.Garden);
    }

}
