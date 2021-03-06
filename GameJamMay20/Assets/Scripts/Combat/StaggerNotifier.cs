using UnityEngine;
using UnityEngine.Events;

public class StaggerNotifier : MonoBehaviour
{
    [SerializeField] UnityEvent OnStagger;

    public void HandleDamageReceived(DamageDataReceived data)
    {
        if (data.dmgdata.stagger)
        {
            OnStagger?.Invoke();
        }
    }
}
