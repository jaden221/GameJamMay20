using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    List<Transform> hitEnemies = new List<Transform>();

    Collider2D myCol;
    DamageDataStruct damageData;

    void OnTriggerStay2D(Collider2D other)
    {
        if (hitEnemies.Contains(other.transform.root)) return;
        if (transform.root == other.transform.root) return;

        hitEnemies.Add(other.transform.root);

        if (!other.transform.root.TryGetComponent(out DamageReceiver damageReceiver)) return;

        damageReceiver.ReceiveDamage(damageData);
    }

    public void Setup()
    {
        myCol = GetComponent<Collider2D>();
        myCol.enabled = false;
    }

    public void Enable(DamageDataStruct newDamageData)
    {
        damageData = newDamageData;
        hitEnemies.Clear();
        myCol.enabled = true;
    }

    public void Disable()
    {
        myCol.enabled = false;
    }
}
