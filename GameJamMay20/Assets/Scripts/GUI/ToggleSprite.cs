using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Written By Fyfey96
public class ToggleSprite : MonoBehaviour
{
    [SerializeField] Sprite _spriteA;
    [SerializeField] Sprite _spriteB;
    
    Sprite _currentSprite;
   
    bool _toggle = false;

    public void Toggle()
    {
        if (_toggle)
        {
            GetComponent<Image>().sprite = _spriteA;
            _toggle = false;
        }
        else if (!_toggle)
        {
            GetComponent<Image>().sprite = _spriteB;
            _toggle = true;
        }
    }


    
}
