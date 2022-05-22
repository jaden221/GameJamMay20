using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written By Fyfey96
public class ToggleAudio : MonoBehaviour
{  
    bool _musicIsOn = true;
    AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Toggle()
    {
        if (_musicIsOn)
        {
            _audioSource.Stop();
            _musicIsOn = false;
        }
        else if (!_musicIsOn)
        {
            _audioSource.Play();
            _musicIsOn = true;
        }
    }
}
