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

    Animator animator;
    Energy energy;

    void Awake()
    {
        if (dealDamage == null) Debug.Log($"DealDamage is null on {transform.name}");
        animator = GetComponent<Animator>();
        energy = GetComponent<Energy>();
    }

    public void AEvent_StartRoar()
    {
        if (energy.GetCurEnergy >= energyCost)
        {
            energy.AddEnergy(-energyCost);

            //play roar sound effect
            dealDamage.Enable(damageData.GetDamageStruct);
        }
        else
        {
            animator.SetTrigger("Cancel");
        }
        
    }

    public void AEvent_EndRoar()
    {
        dealDamage.Disable();
    }
}
