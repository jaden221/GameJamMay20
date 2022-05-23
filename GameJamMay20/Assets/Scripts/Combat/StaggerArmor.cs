using UnityEngine;

public class StaggerArmor : MonoBehaviour
{
    bool canStagger = true;

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
