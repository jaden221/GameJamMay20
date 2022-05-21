using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageReceiver))]
public class Armor : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] float physDmgRes = 0;
    [SerializeField] [Range(0f, 1f)] float fireDmgRes = 0;
    [SerializeField] [Range(0f, 1f)] float magicDmgRes = 0;

    public void HandleDamageReceived(DamageDataReceived damageType)
    {
        damageType.dmgStruct.physDamage = damageType.dmgStruct.physDamage * (1 - physDmgRes);
        damageType.dmgStruct.fireDamage = damageType.dmgStruct.fireDamage * (1 - fireDmgRes);
        damageType.dmgStruct.magicDamage = damageType.dmgStruct.magicDamage * (1 - magicDmgRes);
    }
}
