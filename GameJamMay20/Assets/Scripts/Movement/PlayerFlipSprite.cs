using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFlipSprite : StateMachineBehaviour
{
    PlayerInputMap input;
    InputAction move;
    SpriteRenderer sprite;
    BoxCollider2D attackCollider;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (sprite == null) sprite = animator.GetComponent<SpriteRenderer>();
        if (attackCollider == null) attackCollider = GameObject.Find("Attack").GetComponent<BoxCollider2D>();

        FlipSprite();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FlipSprite();
    }

    void FlipSprite()
    {
        if (move.ReadValue<Vector2>().x == 0) return;

        if (move.ReadValue<Vector2>().x < 0)
        {
            sprite.flipX = true;
            
            attackCollider.offset.Set(attackCollider.offset.x * -1, attackCollider.offset.y);
            
        }
        else
        {
            sprite.flipX = false;
            
            attackCollider.offset.Set(attackCollider.offset.x * -1, attackCollider.offset.y);
            
        }
    }

    void OnEnable()
    {
        if (input == null) input = new PlayerInputMap();
        move = input.Player.Move;
        move.Enable();
    }

    void OnDisable()
    {
        move.Disable();
    }
}
