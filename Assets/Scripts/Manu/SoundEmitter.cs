using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmitter : ScriptableObject{

    private static SoundEmitter _instance;
    private static GameObject _audioManager= Resources.Load("AudioManager") as GameObject;
    private static ChangeSoundEvent _sound= Resources.Load("ChangeSound") as ChangeSoundEvent;

    public void PlaySFX(AudioClip audio)
    {
        CheckAudioManager();
        _sound.clip = audio;
        _sound.Type = SoundEventType.PlaySfx;
        _sound.Fire();
    }

    public void PlayMusic(AudioClip audio)
    {
        CheckAudioManager();
        _sound.clip = audio;
        _sound.Type = SoundEventType.PlayMusic;
        _sound.Fire();
    }

    public void ToggleSound()
    {
        CheckAudioManager();
        _sound.Type = SoundEventType.ToggleSound;
        _sound.Fire();
    }

    public void ChangeSFXVolume(float value)
    {
        CheckAudioManager();
        _sound.newValue = value;
        _sound.Type = SoundEventType.ChangeSfx;
        _sound.Fire();
    }

    public void ChangeMusicVolume(float value)
    {
        CheckAudioManager();
        _sound.newValue = value;
        _sound.Type = SoundEventType.ChangeSfx;
        _sound.Fire();
    }

    public static SoundEmitter Instance()
    {
        if (_instance == null)
        {
            _instance = new SoundEmitter();

        }
        return _instance;
    }

    private void CheckAudioManager()
    {
        if (GameObject.Find("AudioManager") == null)
        {
            Instantiate(_audioManager);
        }
    }
}
