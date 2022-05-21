using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DealDamage : MonoBehaviour
{
    List<Transform> hitEnemies = new List<Transform>();

    Collider2D col;

    float damage;

    void OnTriggerStay2D(Collider2D other)
    {
        if (transform.root == other.transform.root || hitEnemies.Contains(other.transform.root)) return;

        hitEnemies.Add(other.transform.root);

        if (!other.transform.root.TryGetComponent(out DamageReceiver damageReceiver)) return;

        damageReceiver.ReceiveDamage(damage);
    }

    public void Setup(float newDamage)
    {
        col = GetComponent<Collider2D>();
        col.enabled = false;
        damage = newDamage;
    }

    public void Enable()
    {
        col.enabled = true;
    }

    public void Disable()
    {
        col.enabled = false;
    }
}
