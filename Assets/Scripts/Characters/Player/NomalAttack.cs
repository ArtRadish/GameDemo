using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NomalAttack : MonoBehaviour, IAttack
{
    private const string kNormalAttack = "NormalAttack";
    private const string kIsAttack = "IsAttack"; 
    [Header("Attack Settings")]
    [SerializeField] private float coolingTime = 1.0f;
    [SerializeField] private float continuousAttackTime = 2.0f; //连续攻击冷却时间
    [SerializeField] private int AttackNumber = 1;

    private Animator _animator;

    private float _coolingDecayTime;
    private float _curContinuousAttackTime;
    private int _AttackIndex = -1;
    private bool _isAttack = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        AttackManager.Instance.attacks.Add((int)AttackType.NOMALATTACK, this);
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        _animator.SetInteger(kNormalAttack, _AttackIndex);
        _animator.SetBool(kIsAttack, _isAttack);
    }

    public void AttackAction()
    {
        if (_isAttack)
            return;

        _isAttack = true;
        _AttackIndex++;
        _AttackIndex = _AttackIndex % AttackNumber;
        _coolingDecayTime = coolingTime;
        _curContinuousAttackTime = continuousAttackTime;
    }

    public void AttackRestore()
    {
        if (_coolingDecayTime > 0)
            _coolingDecayTime -= Time.deltaTime;
        else
            _isAttack = false;

        if (_curContinuousAttackTime > 0)
            _curContinuousAttackTime -= Time.deltaTime;
        else
            _AttackIndex = -1;
    }
}
