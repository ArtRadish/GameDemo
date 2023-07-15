using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { NONE,NOMALATTACK, SKILLATTACK,FLIPATTACK ,RUNTOFLIPATTACK}
public class AttackManager : Singleton<AttackManager>
{
    public Dictionary<int,IAttack> attacks = new Dictionary<int, IAttack>();

    private AttackType _attackType;
    private bool _isLeftMouseButton;
    private bool _isFlyingKick;
    private bool _isFlip;
    private bool _isRunToFlip;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        PlayerInput.Instance.leftMouseAction += GetIsLeftMouse;
        PlayerInput.Instance.flyingKickButtonAction += GetIsFlyingKick;
        PlayerInput.Instance.flipButtonAction += GetIsFlip;
        PlayerInput.Instance.runToFlipButtonAction += GetIsRunToFlip;
    }

    private void Update()
    {
        AttackState();

        foreach(var attack in attacks)
        {
            attack.Value.AttackRestore();
        }
        //for (int i = 0; i < attacks.Count; i++)
        //{
        //    attacks[i].AttackRestore();
        //}
    }

    private void AttackState()
    {
        switch(_attackType)
        {
            case AttackType.NONE:
                Attack();
                break;
            case AttackType.NOMALATTACK:
                attacks[(int)AttackType.NOMALATTACK].AttackAction();
                _attackType = AttackType.NONE;
                break;
            case AttackType.SKILLATTACK:
                attacks[(int)AttackType.SKILLATTACK].AttackAction();
                _attackType = AttackType.NONE;
                break;
            case AttackType.FLIPATTACK:
                attacks[(int)AttackType.FLIPATTACK].AttackAction();
                _attackType = AttackType.NONE;
                break;
            case AttackType.RUNTOFLIPATTACK:
                attacks[(int)AttackType.RUNTOFLIPATTACK].AttackAction();
                _attackType = AttackType.NONE;
                break;
            default:
                break;
        }
    }

    private void Attack()
    {
        if (_isLeftMouseButton)
        {
            _attackType = AttackType.NOMALATTACK;
            _isLeftMouseButton = false;
            return;
        }
        if (_isFlyingKick)
        {
            _attackType = AttackType.SKILLATTACK;
            _isFlyingKick = false;
            return;
        }
        if (_isFlip)
        {
            _attackType = AttackType.FLIPATTACK;
            _isFlip = false;
            return;
        }
        if (_isRunToFlip)
        {
            _attackType = AttackType.RUNTOFLIPATTACK;
            _isRunToFlip = false;
            return;
        }
    }

    private void GetIsLeftMouse()
    {
        _isLeftMouseButton = true;
    }

    private void GetIsFlyingKick()
    {
        _isFlyingKick = true;
    }

    private void GetIsFlip()
    {
        _isFlip = true;
    }

    private void GetIsRunToFlip()
    {
        _isRunToFlip = true;
    }
}
