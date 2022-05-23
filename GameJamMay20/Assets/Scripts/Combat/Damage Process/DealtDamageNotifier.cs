using UnityEngine;
using System;

public class DealtDamageNotifier : MonoBehaviour
{
	public event Action OnDealtDamage;

    public void DealtDamage()
    {
        OnDealtDamage?.Invoke();
    }
}
