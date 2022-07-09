using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCharger: MonoBehaviour
{
    [SerializeField] private SceneLoader.Scene scene;
    public void ChangeScene()
    {
        SceneLoader.Load(scene);
    }
}
