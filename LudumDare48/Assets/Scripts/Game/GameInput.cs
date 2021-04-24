using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private Controls controls;
    
    private void Awake()
    {
        controls = new Controls();
        SetInputEnabled(true);
    }
    
    public void SetInputEnabled(bool enabled)
    {
        if (enabled)
        {
            controls.DefaultMap.Enable();
        }
        else
        {
            controls.DefaultMap.Disable();
        }
    }
    
    #region mouse
    //--------------------------------------------------------------------------------------------------------------
    public Vector2 GetMousePosition()
    {
        return Mouse.current.position.ReadValue();
    }
    
    public Vector2 GetMouseWorldPosition()
    {
        return Game.inst.mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
    //--------------------------------------------------------------------------------------------------------------
    #endregion mouse

    #region movement axes
    //--------------------------------------------------------------------------------------------------------------
    public float GetHorizontalMovement()
    {
        return controls.DefaultMap.HorizontalMovement.ReadValue<float>();
    }
    
    public float GetVerticalMovement()
    {
        return controls.DefaultMap.VerticalMovement.ReadValue<float>();
    }
    //--------------------------------------------------------------------------------------------------------------
    #endregion movement axes

    #region buttons
    //--------------------------------------------------------------------------------------------------------------
    #region left mouse button
    //--------------------------------------------------------------------------------------------------------------
    public bool GetLeftMouseButtonDown()
    {
        return GetButtonDown(controls.DefaultMap.LeftMouseButton);
    }
    
    public bool GetLeftMouseButton()
    {
        return GetButton(controls.DefaultMap.LeftMouseButton);
    }
    
    public bool GetLeftMouseButtonUp()
    {
        return GetButtonUp(controls.DefaultMap.LeftMouseButton);
    }
    //--------------------------------------------------------------------------------------------------------------
    #endregion left mouse button
    
    #region quit button
    //--------------------------------------------------------------------------------------------------------------
    public bool GetQuitButtonDown()
    {
        return GetButtonDown(controls.DefaultMap.Quit);
    }
    
    public bool GetQuitButton()
    {
        return GetButton(controls.DefaultMap.Quit);
    }
    
    public bool GetQuitButtonUp()
    {
        return GetButtonUp(controls.DefaultMap.Quit);
    }
    //--------------------------------------------------------------------------------------------------------------
    #endregion quit button
    
    #region dash button
    //--------------------------------------------------------------------------------------------------------------
    public bool GetDashButtonDown()
    {
        return GetButtonDown(controls.DefaultMap.Dash);
    }
    
    public bool GetDashButton()
    {
        return GetButton(controls.DefaultMap.Dash);
    }
    
    public bool GetDashButtonUp()
    {
        return GetButtonUp(controls.DefaultMap.Dash);
    }
    //--------------------------------------------------------------------------------------------------------------
    #endregion dash button
    
    #region buttons general
    //--------------------------------------------------------------------------------------------------------------
    private bool GetButtonDown(InputAction action)
    {
        return action.triggered && action.ReadValue<float>() > 0;
    }
        
    private bool GetButton(InputAction action)
    {
        return action.ReadValue<float>() > 0;
    }
        
    private bool GetButtonUp(InputAction action)
    {
        return action.triggered && action.ReadValue<float>() == 0;
    }
    //--------------------------------------------------------------------------------------------------------------
    #endregion buttons general
    //--------------------------------------------------------------------------------------------------------------
    #endregion buttons
}
