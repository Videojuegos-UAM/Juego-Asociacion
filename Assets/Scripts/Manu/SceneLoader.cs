using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader 
{
    private enum Scene
    {
        main,
        coffee,
    }

    private static void Load (Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
