using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float curHealth;

    ReceiveDamage receiveDamage;

    public float GetCurHealth
    {
        get { return curHealth; }
    }

    public event Action OnDeath;

    void Awake()
    {
        receiveDamage = GetComponent<ReceiveDamage>();
    }

    void OnEnable()
    {
        receiveDamage.OnTakeDamage += HandleTakeDamage;
    }

    void OnDisable()
    {
        receiveDamage.OnTakeDamage -= HandleTakeDamage;
    }

    void HandleTakeDamage(float damage)
    {
        curHealth -= damage;
        curHealth = Mathf.Clamp(curHealth, 0, maxHealth);

        if (curHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
