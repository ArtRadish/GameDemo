using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour
{
    const string kJump = "Jump";

    [Header("Base Setting")]
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpTimeout = 0.5f;

    private GroundChecker _groundChecker;
    private Movement _movement;
    private float _jumpTimeoutDelta = -1f;
    private float _curVelocity;

    private void Start()
    {
        _groundChecker = GetComponent<GroundChecker>();
        _movement = GetComponent<Movement>();

        PlayerInput.Instance.jumpAction += Jumpping;
    }

    private void Update()
    {
        CalVerticalSpeed();
    }

    private void Jumpping()
    {
        if (_groundChecker.IsOnGround && _jumpTimeoutDelta <= 0f)
        {
            _curVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            _movement.animator.SetBool(kJump, true);
        }
    }

    void CalVerticalSpeed()
    {
        if (_groundChecker.IsOnGround)
            OnGroundAction();
        else
            LeaveGroundAction();
        _movement._controller.Move(_curVelocity * Vector3.up * Time.deltaTime);
    }

    void OnGroundAction()
    {
        if (_curVelocity < 0f)
            _curVelocity = -2f;

        if (_jumpTimeoutDelta >= 0f)
            _jumpTimeoutDelta -= Time.deltaTime;
    }

    void LeaveGroundAction()
    {
        _movement.animator.SetBool(kJump, false);
        _jumpTimeoutDelta = jumpTimeout;
        _curVelocity += gravity * Time.deltaTime;
    }
}
