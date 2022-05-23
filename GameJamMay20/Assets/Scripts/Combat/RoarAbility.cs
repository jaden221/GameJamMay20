using UnityEngine;

public class RoarAbility : MonoBehaviour
{
	[SerializeField] float energyCost = 60;
    public float GetEnergyCost
    {
        get { return energyCost; }
    }

    [SerializeField] DamageDataSO damageData;
    [SerializeField] DealDamage dealDamage;
    [SerializeField] AudioClip audioClip;
    Energy energy;
    void Awake()
    {
        if (dealDamage == null) Debug.Log($"DealDamage is null on {transform.name}");
        energy = GetComponent<Energy>();
    }

    public void AEvent_StartRoar()
    {
        //play roar sound effect
        dealDamage.Enable(damageData.GetDamageStruct);
        energy.AddEnergy(-GetEnergyCost);
    }

    public void AEvent_EndRoar()
    {
        dealDamage.Disable();
    }
}
