using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Dodge : MonoBehaviour
{
    [SerializeField] float actionVelocity = 5;
    [SerializeField] float recoveryVelocity = 1;
    bool dodging = false;

    Vector2 direction = new Vector2();
    public Vector2 SetDodgeDirection
    {
        set
        {
            direction = value;
        }
    }

    Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void HandleDamageReceived(DamageDataReceived data)
    {
        if (dodging)
        {
            data.dmgdata.physDamage = 0;
            data.dmgdata.fireDamage = 0;
            data.dmgdata.magicDamage = 0;

            data.dmgdata.stagger = false;
        }
    }

    public void AEvent_StartDodge()
    {
        dodging = true;
        rigidbody.velocity = direction * actionVelocity;
    }

    public void AEvent_DodgeRecovery()
    {
        dodging = false;
        rigidbody.velocity = direction * recoveryVelocity;
    }

    public void AEvent_EndDodge()
    {
        rigidbody.velocity = Vector2.zero;
    }
}
