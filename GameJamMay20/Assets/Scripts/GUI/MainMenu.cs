using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject muteButton;
    Sprite SoundOn;
    Sprite SoundOff;
    bool _musicIsOn = true;
    AudioSource _audioSource;

    void Awake()
    {
        SoundOn = Resources.Load<Sprite>("UI/button_29");
        SoundOff = Resources.Load<Sprite>("UI/button_34");
        _audioSource = GetComponent<AudioSource>();
        
    }
    public void ExitGame()
    {
        //This only works when game is built 
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ToggleAudio()
    {
        if (_musicIsOn)
        {
            muteButton.GetComponent<Button>().image.sprite = SoundOff;
            _audioSource.Stop();
            _musicIsOn = false;
            
        }
        else if (!_musicIsOn)
        {
            muteButton.GetComponent<Button>().image.sprite = SoundOn;
            _audioSource.Play();
            _musicIsOn = true;
        }
        

    }
}
