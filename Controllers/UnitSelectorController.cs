using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitSelectorController : SingletonMonobehaviour<UnitSelectorController>
{
    private InputActions unitSelectorInputActions;
    private Vector2 movementDirection;
    private bool selectionAttempt=false;

    //Properties
    public bool SelectionAttempt{get{return selectionAttempt;} set{selectionAttempt=value;}}
    
    protected override void Awake()
    {
        base.Awake();
        unitSelectorInputActions=new InputActions();
        unitSelectorInputActions.UnitSelector_Base.Enable();
        unitSelectorInputActions.UnitSelector_Base.UnitSelectorMovement.performed+=MoveSelector;
        unitSelectorInputActions.UnitSelector_Base.UnitSelectorMovement.performed+=SelectUnit;
        unitSelectorInputActions.UnitSelector_Base.UnitSelectorMovement.performed+=OpenPauseMenu;

    }

   


    public void MoveSelector(InputAction.CallbackContext context)
    {
        Debug.Log("Movement event");
        movementDirection=unitSelectorInputActions.UnitSelector_Base.UnitSelectorMovement.ReadValue<Vector2>();
        Debug.Log(movementDirection);
        Vector2 selectorOffset=new Vector2(transform.position.x,transform.position.y)+movementDirection;
        if(LevelGrid.Instance.CheckPositionValid(selectorOffset))
        {
            transform.position=selectorOffset;
        }


    }


    public void SelectUnit (InputAction.CallbackContext context)
    {
        SwitchSelectorStatus();
    }


    public void OpenPauseMenu(InputAction.CallbackContext context)
    {
        Debug.Log("Called pause menu");
    }

    public TilemapGridNode GetCurrentNode()
    {
        return LevelGrid.Instance.GetNodeAtPosition(transform.position);
    }

    public void SwitchSelectorStatus()
    {
        selectionAttempt=!selectionAttempt;
    }

    public void SetSelectorActive(bool active)
    {
        throw new NotImplementedException();
    }

    public Vector2 GetGridPosition()
    {
        throw new NotImplementedException();
    }

    public Vector2 MakeSelection()
    {
        throw new NotImplementedException();
    }
    







    
}
