using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] [Range(1, 3)] float energyMult = 1.3f;
    [SerializeField] [Range(0, 1)] float damageResistance = .3f;

    bool blocking = false;

    public void HandleDamageReceived(DamageDataReceived damageData)
    {
        if (blocking)
        {
            damageData.dmgdata.energyDamage *= energyMult;
            damageData.dmgdata.physDamage *= (1 - damageResistance);
        }
    }

    public void AEvent_StartBlock()
    {
        blocking = true;
    }

    public void AEvent_EndBlock()
    {
        blocking = false;
    }
}
