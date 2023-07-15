using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    const string kSpeed = "Speed";

    [Header("Movement Setting")]
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float desiredRotationSpeed = 0.1f;

    [HideInInspector] public float acceleration = 1.0f;
    [HideInInspector] public Animator animator;
    [HideInInspector] public Vector3 curVelocity;
    [HideInInspector] public CharacterController _controller;

    private Vector2 _horizontalVertical;
    private Vector3 _moveDirection;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        PlayerInput.Instance.moveAction += GetMoveValue;
    }

    private void Update()
    {
        Move();
        SetAnimationState();
    }

    private void GetMoveValue(Vector2 Value)
    {
        _horizontalVertical = Value;
    }

    private void Move()
    {
        _moveDirection = (_horizontalVertical.x * Vector3.right + _horizontalVertical.y * Vector3.forward).normalized;
        curVelocity = _moveDirection * moveSpeed * Time.deltaTime * acceleration;
        _controller.Move(curVelocity);

        if (_moveDirection.sqrMagnitude <= 0.0f)
            return;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_moveDirection), desiredRotationSpeed * acceleration);
    }

    private void SetAnimationState()
    {
        animator.SetFloat(kSpeed, _moveDirection.sqrMagnitude * acceleration);
        //Debug.Log(_moveDirection.sqrMagnitude * acceleration);
    }
}
