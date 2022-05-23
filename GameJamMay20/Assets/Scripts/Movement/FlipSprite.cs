using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlipSprite : StateMachineBehaviour
{
    PlayerInputMap input;
    InputAction move;
    SpriteRenderer sprite;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (sprite == null) sprite = animator.GetComponent<SpriteRenderer>();

        if (move.ReadValue<Vector2>().x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (move.ReadValue<Vector2>().x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
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
