using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] DamageDataStruct damageData;

    [SerializeField] AudioClip audioClip;
    [SerializeField] DealDamage dealDamage;

    void Awake()
    {
        if (dealDamage == null) Debug.Log($"DealDamage is null on {transform.name}");
        dealDamage.Setup(damageData);
    }

    //if chain of different basic attacks then call those based on chain...
    //That would be a ChainBasicAttack script that inherits from this though

    public void AEvent_StartAttack()
    {
        dealDamage.Enable();
    }

    public void AEvent_EndAttack()
    {
        dealDamage.Disable();
    }
}
