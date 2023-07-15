using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToFlipAttack : MonoBehaviour,IAttack
{
    private const string kIsRunToFlip = "IsRunToFlip";

    [Header("Attack Settings")]
    [SerializeField] private float coolingTime = 1.0f;
    [SerializeField] private float continuousAttackTime = 2.0f; //连续攻击冷却时间
    [SerializeField] private int AttackNumber = 1;
    [SerializeField] private float consumeEnergy = 0.1f;

    private Animator _animator;

    private float _coolingDecayTime;
    private float _curContinuousAttackTime;
    private int _AttackIndex = -1;
    private bool _isAttack = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        AttackManager.Instance.attacks.Add((int)AttackType.RUNTOFLIPATTACK,this);
    }

    private void Update()
    {
        UpdateAnimation();
    }

    public void UpdateAnimation()
    {
        _animator.SetBool(kIsRunToFlip, _isAttack);
    }

    public void AttackAction()
    {
        if (_isAttack)
            return;
        if (!EnergyCheck())
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

    private bool EnergyCheck()
    {
        if (EnergyManager.Instance.EnergyValue < consumeEnergy)
            return false;

        EnergyManager.Instance.EnergyValue -= consumeEnergy;
        return true;
    }
}
