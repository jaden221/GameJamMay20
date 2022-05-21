using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    List<Transform> hitEnemies = new List<Transform>();

    Collider2D col;

    void Awake()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.root == transform.root)
        {

        }
    }
}
