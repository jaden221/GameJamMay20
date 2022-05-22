using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Take input and change anim bool
    #region Input

    PlayerInputMap input;

    InputAction move;
    InputAction basicAtk;

    #endregion

    #region Components

    Animator animator;

    #endregion

    enum TransBools
    {
        Move,
        BasicAttack,
        Dodge,
        Block,
    }

    void Awake()
    {
        animator = GetComponent<Animator>();

        input = new PlayerInputMap();
    }

    void OnEnable()
    {
        move = input.Player.Move;
        move.Enable();

        basicAtk = input.Player.BasicAttack;
        basicAtk.Enable();
    }

    void OnDisable()
    {
        move.Disable();
        basicAtk.Disable();
    }

    void Update()
    {
        animator.SetBool(TransBools.Move.ToString(), move.ReadValue<Vector2>().magnitude > 0);
        animator.SetBool(TransBools.BasicAttack.ToString(), basicAtk.IsPressed());
    }
}
