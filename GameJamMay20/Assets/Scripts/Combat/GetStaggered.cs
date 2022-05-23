using UnityEngine;

public class GetStaggered : MonoBehaviour
{
    [SerializeField] string animBool = "Staggered";

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void HandleStaggered()
    {
        animator.SetBool(animBool, true);
    }

    public void AEvent_EndStagger()
    {
        animator.SetBool("Staggered", false);
    }
}