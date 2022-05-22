using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{

    [SerializeField] float maxHealth;
    [SerializeField] float curHealth;

    public event Action OnDeath;

    #region Getters

    public float GetHealthPercent
    {
        get { return curHealth / maxHealth; }
    }

    public float GetCurHealth
    {
        get { return curHealth; }
    }

    #endregion

    void Awake()
    {
        if (maxHealth <= 0) Debug.Log($"maxHealth is set to 0 on {transform.name}");

        curHealth = maxHealth;
    }

    public void HandleDamagedReceived(DamageDataReceived damagedata) //Switch param to be of type DamageType
    {
        curHealth -= damagedata.dmgdata.TotalDamage();
        curHealth = Mathf.Clamp(curHealth, 0, maxHealth);

        if (curHealth == 0) OnDeath?.Invoke();
    }

    public void AddHealth(float value)
    {
        curHealth += value;
        curHealth = Mathf.Clamp(curHealth, 0f, maxHealth);
    }

    /// <summary>
    /// Use intended for Animation Event after Object Death
    /// </summary>
    public void AnEvent_Destroy()
    {
        Destroy(gameObject);
    }
}