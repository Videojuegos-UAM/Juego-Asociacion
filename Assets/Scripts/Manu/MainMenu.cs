using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    private ChangeSoundEvent _sound;
    [SerializeField] private GameObject _mainPanel, _creditsPanel;
    private bool _music = true;
    private bool _sfx = true;
    private float _musicVolume = 0.5f;
    private float _sfxVolume = 0.5f;
    // Start is called before the first frame update
    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        Time.timeScale = 1f;
        SceneLoader.Load(SceneLoader.Scene.Garden);
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

    public void Credits()
    {
        _creditsPanel.SetActive(true);
        _mainPanel.SetActive(false);
    }

    public void Main()
    {
        _creditsPanel.SetActive(false);
        _mainPanel.SetActive(true);
    }
}
