using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image _fillImage;
    [SerializeField] bool autoFillHealth = true;
    [SerializeField] Health health;

    void Awake()
    {
        _fillImage = GetComponent<Image>();
        if (autoFillHealth) health = transform.root.GetComponent<Health>();
        if (health == null) Debug.Log($"Health is null on {transform.name}"); ;
    }

    void Update()
    {
        _fillImage.fillAmount = health.GetHealthPercent;
    }
}
