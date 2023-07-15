using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Sprint : MonoBehaviour
{
    [SerializeField, Range(1, 5)] private float sprintSpeedMultiple = 1.5f;
    [SerializeField] private float energyUseSpeedMultiple = 0.1f;

    private Movement _movement;
    private bool _isSprintButton;
    private float _curSprintSpeed;

    [HideInInspector]public bool isSprint;

    private void Start()
    {
        _movement = GetComponent<Movement>();
        _curSprintSpeed = _movement.acceleration;

        PlayerInput.Instance.sprintAction += GetIsSprint;
    }

    private void Update()
    {
        isSprint = Accelerate();
        Recover();
    }

    private void GetIsSprint(bool isSprint)
    {
        _isSprintButton = isSprint;
    }

    private bool Accelerate()
    {
        if (!_isSprintButton || !EnergyManager.Instance.PossessEnergy())
            return false;

        if (_curSprintSpeed < sprintSpeedMultiple)
            _curSprintSpeed += Time.deltaTime;
        _movement.acceleration = _curSprintSpeed;
        EnergyManager.Instance.EnergyValue -= Time.deltaTime * energyUseSpeedMultiple;
        return true;
    }

    private void Recover()
    {
        if (_isSprintButton && EnergyManager.Instance.PossessEnergy())
            return;

        if (_curSprintSpeed > 1.0f)
            _curSprintSpeed -= Time.deltaTime;
        _movement.acceleration = _curSprintSpeed;
    }
}
