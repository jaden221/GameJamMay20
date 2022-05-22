using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DamageDataStruct
{
    // TODO
    // Put getters int the DamageData SO simply to reduce line length,
    // the SO shouldn't hold values on its own... only getters

    public float physDamage;
    float physDamageTrue;
    public float PhysDamageTrue
    {
        get { return physDamageTrue; }
    }

    public float fireDamage;
    float fireDamageTrue;
    public float FireDamageTrue
    {
        get { return fireDamageTrue; }
    }

    public float magicDamage;
    float magicDamageTrue;
    public float MagicDamageTrue
    {
        get { return magicDamageTrue; }
    }

    public float energyDamage;
    float energyDamageTrue;
    public float EnergyDamageTrue
    {
        get { return energyDamageTrue; }
    }

    public bool stagger;

    public float TotalDamage()
    {
        return physDamage + fireDamage + magicDamage;
    }

    public void SetTrueValues()
    {
        //Keep the original values of the attack set by the designer
        physDamageTrue = physDamage;
        fireDamageTrue = fireDamage;
        magicDamageTrue = magicDamage;
    }
}
