using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Written by Fyfey96

public class EnergyBar : MonoBehaviour
{
    Image _fillImage;

    [SerializeField] Energy _energy;

    void Awake()
    {
        _fillImage = GetComponent<Image>();
    }

    void Update()
    {
        _fillImage.fillAmount = _energy.GetEnergyPercent;
    }
}
