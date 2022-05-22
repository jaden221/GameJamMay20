using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] float _attackDistance;

    Animator animator;

    Transform _playerTrans;

    bool _canBasicAttack = false;

    enum TransBools
    {
        Move,
        BasicAttack,
    }

    void Awake()
    {
        animator = GetComponent<Animator>();

        _playerTrans = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        _canBasicAttack = Vector2.Distance(_playerTrans.position, transform.position) <= _attackDistance;
        
        animator.SetBool(TransBools.BasicAttack.ToString(), _canBasicAttack);    
    }
}
