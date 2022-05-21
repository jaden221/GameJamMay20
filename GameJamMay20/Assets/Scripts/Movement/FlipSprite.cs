using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : StateMachineBehaviour
{
    Rigidbody2D rigidbody;
    SpriteRenderer sprite;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (sprite == null) sprite = animator.GetComponent<SpriteRenderer>();
        if (rigidbody == null) rigidbody = animator.transform.root.GetComponentInChildren<Rigidbody2D>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        sprite.flipX = rigidbody.velocity.x < 0;
    }
}
