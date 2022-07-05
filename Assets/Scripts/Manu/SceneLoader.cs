using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader 
{
    public enum Scene
    {
        main,
        coffee,
<<<<<<< Updated upstream
=======
        Violeta,
        menu,
>>>>>>> Stashed changes
    }

    public static void Load (Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
