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
        damageType.dmgdata.physDamage = damageType.dmgdata.physDamage * (1 - physDmgRes);
        damageType.dmgdata.fireDamage = damageType.dmgdata.fireDamage * (1 - fireDmgRes);
        damageType.dmgdata.magicDamage = damageType.dmgdata.magicDamage * (1 - magicDmgRes);
    }
}
