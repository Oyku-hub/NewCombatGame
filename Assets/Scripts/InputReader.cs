using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Control.IPlayerActions
{
    public Vector2 MovementValue { get; private set; }
    private Control controls;
    public event Action JumpEvent;
    public event Action DodgeEvent;

    private void Start()
    {
        controls = new Control();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
        
    }
    private void OnDestroy()
    {
        controls.Player.Disable();

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        JumpEvent?.Invoke();
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        DodgeEvent?.Invoke();
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
        
    }

    public void OnLook(InputAction.CallbackContext context)
    {
       
    }
}



