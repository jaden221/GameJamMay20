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
    public float GetEnergyPercent
    {
        get { return curEnergy / maxEnergy; }
    }

    [SerializeField] float degenAmount = 1f;
    [SerializeField] float degenInterval = 1;
    float curDegenInterval;

    public void HandleDamagedReceieved(DamageDataReceived damageData)
    {
        curEnergy += damageData.dmgdata.energyDamage;
        curEnergy = Mathf.Clamp(curEnergy, 0, maxEnergy);
    }

    void Update()
    {
        if (curDegenInterval < degenInterval)
        {
            curDegenInterval += Time.deltaTime;
        }
        else
        {
            curEnergy -= degenAmount;
            curEnergy = Mathf.Clamp(curEnergy, 0, maxEnergy);
            curDegenInterval = 0;
        }
    }
}
