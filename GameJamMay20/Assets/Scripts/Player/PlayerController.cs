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
    InputAction dodge;
    InputAction block;
    InputAction ability1;
    InputAction ability2;

    #endregion

    #region Components

    Animator animator;
    Energy energy;
    RoarAbility roarAbility;
    Health health;

    #endregion

    enum TransBools
    {
        Move,
        BasicAttack,
        Dodge,
        Block,
        Ability1,
        Ability2,
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        energy = GetComponent<Energy>();
        roarAbility = GetComponent<RoarAbility>();

        input = new PlayerInputMap();
    }

    void OnEnable()
    {
        move = input.Player.Move;
        move.Enable();

        basicAtk = input.Player.BasicAttack;
        basicAtk.Enable();

        dodge = input.Player.Dodge;
        dodge.Enable();

        block = input.Player.Block;
        block.Enable();

        ability1 = input.Player.Ability1;
        ability1.Enable();

        ability2 = input.Player.Ability2;
        ability2.Enable();
    }

    void OnDisable()
    {
        move.Disable();
        basicAtk.Disable();
        dodge.Disable();
        block.Disable();
        ability1.Disable();
        ability2.Disable();
    }

    void Update()
    {
        animator.SetBool(TransBools.Move.ToString(), move.ReadValue<Vector2>().magnitude > 0);
        animator.SetBool(TransBools.BasicAttack.ToString(), basicAtk.IsPressed());
        animator.SetBool(TransBools.Dodge.ToString(), dodge.IsPressed());
        animator.SetBool(TransBools.Block.ToString(), block.IsPressed());
        CanRoar();
        animator.SetBool(TransBools.Ability2.ToString(), ability2.IsPressed());
    }

    void CanRoar()
    {
        if (ability1.IsPressed() && energy.GetCurEnergy >= roarAbility.GetEnergyCost)
        {
            animator.SetBool(TransBools.Ability1.ToString(), true);
        }
        else
        {
            animator.SetBool(TransBools.Ability1.ToString(), false);
        }
    }

    public void DisableMove()
    {
        move.Disable();
    }

    public void EnableMove()
    {
        move.Enable();
    }
}
