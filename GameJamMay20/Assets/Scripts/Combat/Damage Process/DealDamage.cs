using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    List<Transform> hitEnemies = new List<Transform>();
    DamageDataStruct damageData;

    Collider2D myCol;
    DealtDamageNotifier notifier;

    void Awake()
    {
        myCol = GetComponent<Collider2D>();
        myCol.enabled = false;
        notifier = transform.root.GetComponent<DealtDamageNotifier>();
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

    void OnTriggerStay2D(Collider2D other)
    {
        if (hitEnemies.Contains(other.transform.root)) return;
        if (transform.root == other.transform.root) return;
        if (!other.transform.root.TryGetComponent(out DamageReceiver damageReceiver)) return;

        hitEnemies.Add(other.transform.root);
        damageReceiver.ReceiveDamage(damageData);
        notifier.DealtDamage();
    }
}
