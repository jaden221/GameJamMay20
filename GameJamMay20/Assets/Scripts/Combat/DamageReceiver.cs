using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageReceiver : MonoBehaviour
{
    public event Action<float> OnReceiveDamage;

    public void ReceiveDamage(float damage)
    {
        OnReceiveDamage?.Invoke(damage);
    }
}
