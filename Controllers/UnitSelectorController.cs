using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitSelectorController : SingletonMonobehaviour<UnitSelectorController>
{
    private InputActions unitSelectorInputActions;
    private Vector2 movementDirection;
    private Vector2 selectorGridPosition;
    private bool selectionAttempt=false;
    private TilemapGridNode currentNode;
    private Vector2 gridPosition;

    //Properties
    public bool SelectionAttempt{get{return selectionAttempt;} set{selectionAttempt=value;}}
    
    protected override void Awake()
    {
        base.Awake();
        gridPosition= new Vector2(transform.position.x,transform.position.y);
        unitSelectorInputActions=new InputActions();
        unitSelectorInputActions.UnitSelector_Base.Enable();
        unitSelectorInputActions.UnitSelector_Base.UnitSelectorMovement.performed+=MoveSelector;
        unitSelectorInputActions.UnitSelector_Base.UnitSelection.performed+=SelectUnit;
        unitSelectorInputActions.UnitSelector_Base.Menu.performed+=OpenPauseMenu;

    }

    

    public void MoveSelector(InputAction.CallbackContext context)
    {
        movementDirection=unitSelectorInputActions.UnitSelector_Base.UnitSelectorMovement.ReadValue<Vector2>();
        Vector2 selectorOffset=new Vector2(transform.position.x,transform.position.y)+movementDirection;
        if(LevelGrid.Instance.CheckPositionValid(selectorOffset))
        {
            transform.position=selectorOffset;
            gridPosition= new Vector2(transform.position.x, transform.position.y);

        }


    }

    public Vector2 GetUnitSelectorGridPosition()
    {
        Vector2 worldPosition=new Vector2(transform.position.x,transform.position.y);
        Vector2 gridPosition= LevelGrid.Instance.GetGridPositionFromWorldPosition(worldPosition);
        return gridPosition;
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
        Vector2 gridPosition=GetUnitSelectorGridPosition();
        TilemapGridNode currentNode=LevelGrid.Instance.GetNodeAtPosition(gridPosition);
        return LevelGrid.Instance.GetNodeAtPosition(gridPosition);
    }

    public void SwitchSelectorStatus()
    {
        selectionAttempt=!selectionAttempt;
    }

    public void SetSelectorActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public Vector2 GetGridPosition()
    {
        return gridPosition;
    }

    public Vector2 MakeSelection()
    {
        throw new NotImplementedException();
    }
    







    
}
