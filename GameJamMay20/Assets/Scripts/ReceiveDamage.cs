using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReceiveDamage : MonoBehaviour
{
    public event Action<float> OnTakeDamage;

    public void TakeDamage(float damage)
    {
        OnTakeDamage?.Invoke(damage);
    }
}
