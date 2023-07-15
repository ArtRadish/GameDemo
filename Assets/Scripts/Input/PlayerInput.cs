using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInput : Singleton<PlayerInput>, WorkGame3D.IPlayerActions
{
    public WorkGame3D inputActions;

    public Action<Vector2> moveAction;
    public Action<bool> sprintAction;
    public Action jumpAction;
    public Action leftMouseAction;
    public Action flyingKickButtonAction;
    public Action flipButtonAction;
    public Action runToFlipButtonAction;

    protected override void Awake()
    {
        base.Awake();
        inputActions = new WorkGame3D();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.SetCallbacks(this);
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    public void OnMove(CallbackContext context)
    {
        moveAction?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            jumpAction?.Invoke();
    }

    public void OnMouseLeftButton(CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            leftMouseAction?.Invoke();
    }

    public void OnFlip(CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            flipButtonAction?.Invoke();
    }

    public void OnRunToFlip(CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            runToFlipButtonAction?.Invoke();
    }

    public void OnFlyingKick(CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            flyingKickButtonAction?.Invoke();
    }

    public void OnLook(CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnFire(CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnSprint(CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            sprintAction?.Invoke(true);
        else if(context.phase == InputActionPhase.Canceled)
            sprintAction?.Invoke(false);
    }


}
