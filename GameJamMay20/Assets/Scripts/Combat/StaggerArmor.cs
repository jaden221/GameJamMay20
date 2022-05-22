using UnityEngine;

public class StaggerArmor : MonoBehaviour
{
    [SerializeField] [Tooltip("Can't Stagger but only from Start, Animations can change afterward")]
    bool cantStaggerStart = false;

    bool canStagger = true;

    private void Awake()
    {
        canStagger = !cantStaggerStart;
    }

    public void AEvent_CanStagger()
    {
        canStagger = true;
    }

    public void AEvent_CantStagger()
    {
        canStagger = false;
    }

    public void HandleReceiveDamage(DamageDataReceived data)
    {
        if (data.dmgdata.stagger && !canStagger) data.dmgdata.stagger = false;
    }
}
