using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelVelocity : StateMachineBehaviour
{
    [SerializeField] bool cancelUpdate = true;

    Rigidbody2D rigidbody;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (rigidbody == null) rigidbody = animator.GetComponent<Rigidbody2D>();

        rigidbody.velocity = Vector2.zero;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (cancelUpdate)
        {
            rigidbody.velocity = Vector2.zero;
        }
    }
}
