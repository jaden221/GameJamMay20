using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] DamageDataSO damageData;

    [SerializeField] [Tooltip("Assign this attack's Collider")] DealDamage dealDamage;

    [SerializeField] AudioClip audioClip;

    AudioSource audioSource;

    void Awake()
    {
        if (dealDamage == null) Debug.Log($"DealDamage is null on {transform.name}");
        audioSource = GetComponent<AudioSource>();
    }

    //if chain of different basic attacks then call those based on chain...
    //That would be a ChainBasicAttack script that inherits from this though

    public void AEvent_StartAttack()
    {
        dealDamage.Enable(damageData.GetDamageStruct);
        audioSource.clip = audioClip;
        audioSource.Play();
        //Add the play audio functionality
    }

    public void AEvent_EndAttack()
    {
        dealDamage.Disable();
    }
}
