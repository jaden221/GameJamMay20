using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DamageData", menuName = "DamageData")]
public class DamageDataSO : ScriptableObject
{
    [SerializeField] DamageDataStruct dmgStruct;
    public DamageDataStruct GetDamageStruct
    {
        get { return dmgStruct; }
    }

    private void Awake()
    {
        dmgStruct.SetTrueValues();
    }
}
