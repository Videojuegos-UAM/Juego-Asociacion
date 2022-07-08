using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader 
{
    public enum Scene
    {
        MainMenu,
        Interior,
        Garden,
        Kitchen,
        Miguel,
        Coffee,
        Cooking,
        Violeta,
    }

    public static void Load (Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
