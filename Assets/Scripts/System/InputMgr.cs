using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class InputMgr : Singleton<InputMgr>
{
    public UnityAction<Vector2> OnMoveAction;
    public UnityAction<Vector2> OnLookAction;
    public UnityAction OnJumpAction;
    public UnityAction OnJumpCancelAction;
    public UnityAction OnShootAction;
    public UnityAction OnShootCancelAction;
    public UnityAction OnSprintAction;
    public UnityAction OnSprintCancelAction;

    public string CurrentControlScheme => m_PlayerInput.currentControlScheme;

    [SerializeField]
    private PlayerInput m_PlayerInput;


    protected override void Awake()
    {
        base.Awake();

        if(m_PlayerInput == null)
        {
            m_PlayerInput = GetComponent<PlayerInput>();
        }

        //if (m_Input == null)
        //{
        //    m_Input = new StarterAssets();
        //    m_Input.Player.SetCallbacks(this);
        //}

        //m_Input.Enable();
    }

    private void OnEnable()
    {
        EnableInput();
    }

    private void OnDisable()
    {
        DisableInput();
    }

    public void EnableInput()
    {
        //if (m_Input != null)
        //{
        //    m_Input.Enable();
        //}

        EnhancedTouchSupport.Enable();
    }

    public void DisableInput()
    {
        //if (m_Input != null)
        //{
        //    m_Input.Disable();
        //}

        EnhancedTouchSupport.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnMoveAction?.Invoke(context.ReadValue<Vector2>());
            Debug.Log(context.ReadValue<Vector2>());
        }
        else if(context.canceled)
        {
            OnMoveAction?.Invoke(Vector2.zero);
        }

    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnShootAction?.Invoke();
        }
        else if (context.canceled)
        {
            OnShootCancelAction?.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnJumpAction?.Invoke();
        }
        else if (context.canceled)
        {
            OnJumpCancelAction?.Invoke();
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnLookAction?.Invoke(context.ReadValue<Vector2>());
            Debug.Log(context.ReadValue<Vector2>());
        }
        else if (context.canceled)
        {
            OnLookAction?.Invoke(Vector2.zero);
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnSprintAction?.Invoke();
        }
        else if (context.canceled)
        {
            OnSprintCancelAction?.Invoke();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        
    }
}
