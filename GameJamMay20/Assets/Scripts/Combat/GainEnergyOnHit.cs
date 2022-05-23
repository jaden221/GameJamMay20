using UnityEngine;

[RequireComponent(typeof(DealtDamageNotifier))]
[RequireComponent(typeof(Energy))]
public class GainEnergyOnHit : MonoBehaviour
{
    [SerializeField] float energyPerHit = 10;

    DealtDamageNotifier notifier;
    Energy energy;

    void Awake()
    {
        notifier = GetComponent<DealtDamageNotifier>();
        energy = GetComponent<Energy>();
    } 

    void OnEnable()
    {
        notifier.OnDealtDamage += HandleOnDealtDamage;
    }

    void OnDisable()
    {
        notifier.OnDealtDamage -= HandleOnDealtDamage;
    }

    public void HandleOnDealtDamage()
    {
        energy.AddEnergy(energyPerHit);
    }
}
