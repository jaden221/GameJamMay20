using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelVelocity : StateMachineBehaviour
{
    Rigidbody2D rigidbody;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (rigidbody == null) rigidbody = animator.GetComponent<Rigidbody2D>();

        rigidbody.velocity = Vector2.zero;
    }
}
