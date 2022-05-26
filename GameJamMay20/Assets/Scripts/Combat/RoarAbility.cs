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

    AudioSource audioSource;
    Energy energy;
    void Awake()
    {
        if (dealDamage == null) Debug.Log($"DealDamage is null on {transform.name}");
        energy = GetComponent<Energy>();
        audioSource = GetComponent<AudioSource>();
    }

    public void AEvent_StartRoar()
    {
        dealDamage.Enable(damageData.GetDamageStruct);
        energy.AddEnergy(-GetEnergyCost);

        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void AEvent_EndRoar()
    {
        dealDamage.Disable();
    }
}
