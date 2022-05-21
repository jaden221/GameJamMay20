using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(DamageReceiver))]
public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float curHealth;

    DamageReceiver receiveDamage;

    public float GetCurHealth
    {
        get { return curHealth; }
    }

    public event Action OnDeath;

    void Awake()
    {
        receiveDamage = GetComponent<DamageReceiver>();
    }

    void OnEnable()
    {
        receiveDamage.OnReceiveDamage += HandleTakeDamage;
    }

    void OnDisable()
    {
        receiveDamage.OnReceiveDamage -= HandleTakeDamage;
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
