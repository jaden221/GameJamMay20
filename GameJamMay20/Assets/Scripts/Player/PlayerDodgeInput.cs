using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDodgeInput : MonoBehaviour
{
    Dodge dodge;
    PlayerInputMap input;
    InputAction inDirection;

    void Awake()
    {
        dodge = GetComponent<Dodge>();
        input = new PlayerInputMap();
    }

    void Update()
    {
        dodge.SetDodgeDirection = inDirection.ReadValue<Vector2>();
    }

    void OnEnable()
    {
        inDirection = input.Player.Move;
        inDirection.Enable();
    }

    void OnDisable()
    {
        inDirection.Disable();
    }
}
