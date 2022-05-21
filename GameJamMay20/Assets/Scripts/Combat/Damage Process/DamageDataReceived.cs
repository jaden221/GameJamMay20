using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new DamageDataReceived", menuName = "DamageReceived")]
public class DamageDataReceived : ScriptableObject
{
    //Designer inputs data, the dealer copies the struct and passes it
    [HideInInspector] public DamageDataStruct dmgdata;
}
