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
        unitSelectorInputActions.UnitSelector_Base.UnitSelectorMovement.performed+=MoveSelector;
        unitSelectorInputActions.UnitSelector_Base.UnitSelectorMovement.performed+=SelectUnit;
        unitSelectorInputActions.UnitSelector_Base.UnitSelectorMovement.performed+=OpenPauseMenu;

    }

   


    public void MoveSelector(InputAction.CallbackContext context)
    {
        movementDirection=unitSelectorInputActions.UnitSelector_Base.UnitSelectorMovement.ReadValue<Vector2>();
        Vector2 selectorOffset=transform.position+movementDirection;
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
        //TODO
    }

    public TilemapGridNode GetCurrentNode()
    {
        return LevelGrid.Instance.GetNodeAtPsotion(transform.Position);
    }

    public void SwitchSelectorStatus()
    {
        selectionAttempt=!selectionAttempt;
    }







    
}
