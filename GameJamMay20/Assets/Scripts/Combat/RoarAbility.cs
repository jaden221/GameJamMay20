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
	
    void Awake()
    {
        if (dealDamage == null) Debug.Log($"DealDamage is null on {transform.name}");
    }

    public void AEvent_StartRoar()
    {
        //play roar sound effect
        dealDamage.Enable(damageData.GetDamageStruct);
    }

    public void AEvent_EndRoar()
    {
        dealDamage.Disable();
    }
}
