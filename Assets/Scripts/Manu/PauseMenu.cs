using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pausePanel;
    private bool _music = true;
    private bool _sfx = true;
    private float _musicVolume = 0.5f;
    private float _sfxVolume = 0.5f;

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale=0f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneLoader.Load(SceneLoader.Scene.menu);
    }

    public void ChangeMusicVolume(float f)
    {
        print(f);
        SoundEmitter.Instance().ChangeMusicVolume(f);
    }

    public void ChangeSFXVolume(float f)
    {
        print(f);
        SoundEmitter.Instance().ChangeSFXVolume(f);
    }
    public void ChangeMusicMute(bool b)
    {
        print(b);
        SoundEmitter.Instance().SetMusicMute(b);
    }

    public void ChangeSFXMute(bool b)
    {
        print(b);
        SoundEmitter.Instance().SetSfxMute(b);
    }

}
