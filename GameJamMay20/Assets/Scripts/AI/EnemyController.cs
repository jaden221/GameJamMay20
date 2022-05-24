using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] float basicatkDist = 1;
    float distToPlayer;

    Transform player;

    Animator animator;

    enum TransBools
    {
        Move,
        BasicAttack,
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        // Observers
        CheckPlayerDistance();

        animator.SetBool(TransBools.Move.ToString(), distToPlayer > basicatkDist);
        animator.SetBool(TransBools.BasicAttack.ToString(), distToPlayer <= basicatkDist);
            
    }

    void CheckPlayerDistance()
    {
        distToPlayer = Vector2.Distance(player.position, transform.position);
    }
}
