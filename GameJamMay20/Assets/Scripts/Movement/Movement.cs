using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //This class's function will be called from the StateMachineBehaviour

    [SerializeField] float moveSpeed;

    Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    public void Move(Vector2 direction)
    {
        rigidbody.velocity = direction.normalized * moveSpeed;
    }
}
