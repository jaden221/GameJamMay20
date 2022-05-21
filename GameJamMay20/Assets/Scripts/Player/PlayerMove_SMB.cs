using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove_SMB : StateMachineBehaviour
{
    PlayerInputMap input;
    InputAction move;

    Movement movement;

    Vector2 direction;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (movement == null) movement = animator.GetComponent<Movement>();
    } 

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        direction = input.Player.Move.ReadValue<Vector2>();
        
        movement.Move(direction);
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
