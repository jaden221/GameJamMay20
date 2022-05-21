using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] float maxEnergy = 100;
    [SerializeField] float curEnergy = 0;
    public float GetCurEnergy
    {
        get { return curEnergy; }
    }

    public void HandleDamagedReceieved(DamageDataReceived damageData)
    {
        curEnergy += damageData.dmgdata.energyDamage;
    }
}
