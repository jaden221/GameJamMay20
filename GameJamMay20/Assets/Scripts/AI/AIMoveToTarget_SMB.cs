using UnityEngine;

public class AIMoveToTarget_SMB : StateMachineBehaviour
{
    Movement movement;
    Transform player;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (movement == null) movement = animator.GetComponent<Movement>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 direction = player.position - animator.transform.position;
        movement.Move(direction);
    }
}
