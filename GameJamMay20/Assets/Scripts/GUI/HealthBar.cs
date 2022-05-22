using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Written by Fyfey96

public class HealthBar : MonoBehaviour
{
    Image _fillImage;

    [SerializeField] Health _health;

    void Awake()
    {
        _fillImage = GetComponent<Image>();
    }

    void Update()
    {
        _fillImage.fillAmount = _health.GetHealthPercent;
    }
}
