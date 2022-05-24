using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] float _attackDistance;
    [SerializeField] float _moveSpeed = 2;

    Animator animator;

    PlayerController _player;

    bool _canBasicAttack = false;
    float _distanceToPlayer;

    enum TransBools
    {
        Move,
        BasicAttack,
    }

    void Awake()
    {
        animator = GetComponent<Animator>();

        _player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        CheckPlayerDistance();
        _canBasicAttack = _distanceToPlayer <= _attackDistance;

        
        animator.SetBool(TransBools.Move.ToString(),!_canBasicAttack );
        animator.SetBool(TransBools.BasicAttack.ToString(), _canBasicAttack);    
    }

    private void CheckPlayerDistance()
    {
        _distanceToPlayer = Vector2.Distance(_player.transform.position, transform.position);
    }
}
