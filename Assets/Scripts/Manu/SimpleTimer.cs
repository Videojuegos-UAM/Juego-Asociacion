using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTimer : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private GameEventScriptable gameEventScriptable;

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            gameEventScriptable.Fire();
        }
    }
}
