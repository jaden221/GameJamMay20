using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField] DamageDataReceived dmgData;

    [Tooltip("Add OnDamageReceivedHandler here")] public UnityEvent<DamageDataReceived> OnDamageReceived;

    void Awake()
    {
        if (dmgData == null) Debug.Log($"Damage Data Received is null on {transform.root.name}");
    }

    public void ReceiveDamage(DamageDataStruct damageStruct)
    {
        //Reset the damageType here then set to the passed one
        dmgData.dmgStruct = damageStruct;
        OnDamageReceived?.Invoke(dmgData);
    }
    //Keep copy of damageType Passed in and then let the scripts use that maybe?
}
