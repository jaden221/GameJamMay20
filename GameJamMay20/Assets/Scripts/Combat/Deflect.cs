using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflect : MonoBehaviour
{
    [SerializeField] [Range(1, 5)] float energyMult = 2.5f;

    bool deflecting;

    public void HandleDamageReceived(DamageDataReceived damageData)
    {
        if (deflecting)
        {
            damageData.dmgdata.energyDamage *= energyMult;
            damageData.dmgdata.physDamage *= 0;
        }
    }

    public void AEvent_StartDelfecting()
    {
        deflecting = true;
    }

    public void AEvent_EndDelfecting()
    {
        deflecting = false;
    }

    public void HandleStaggered()
    {
        deflecting = false;
    }
}
