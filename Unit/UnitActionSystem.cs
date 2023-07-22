using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitActionSystem : SingletonMonobehaviour<UnitActionSystem>
{
   
    //Events
    public event EventHandler OnSelectedUnitChanged;
    public event EventHandler OnDeselectedUnit;
    public event EventHandler OnActionPositionSelected;
    public event EventHandler OnActionTaken;
    //Fields
    private Unit selectedUnit;
    private BaseAction baseAction=null;
    Vector2 actionPosition;
    private bool isBusy;
    protected override void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        if(!UnitSelectorController.Instance.SelectionAttempt)
        {
            return;
        }
        if(TryHandleUnitSelection())
        {
            return;
        }
        if(TryHandleUnitActionMenu())
        {
            return;
        }

    }
 
    private bool TryHandleUnitSelection()
    {
        TilemapGridNode selectorCurrentNode=UnitSelectorController.Instance.GetCurrentNode();
        if(selectorCurrentNode.HasAnyUnit() && selectedUnit==null)
        {
            
            Unit nodeUnit=selectorCurrentNode.GetUnit();        
            //Unit already selected
            if(selectedUnit==nodeUnit)
            {
                return false;
            }
            //Unit has already completed action
            if(nodeUnit.UnitCompletedAction())
            {
                return false;
            }
            //Unit is an enemy;
            if(nodeUnit.IsEnemy())
            {
                Debug.Log("Enemy Detected");
                return false;
            }
            SetSelectedUnit(nodeUnit);
            UnitSelectorController.Instance.SwitchSelectorStatus();
            return true;

        }
        Vector2 unitSelectorActionNodePosition= UnitSelectorController.Instance.GetUnitSelectorGridPosition();
        if(selectedUnit!=null)
        {
            Debug.Log(selectedUnit.ValidAttackPositions.Count);
            Debug.Log($"Unit selector position {unitSelectorActionNodePosition}");
            foreach(Vector2 position in selectedUnit.ValidAttackPositions)
            {
                Debug.Log($"attack position {position}");
            }
            bool movementPositionFound=selectedUnit.ValidMovementPositions.Contains(unitSelectorActionNodePosition);
            bool attackPositionFound=selectedUnit.ValidAttackPositions.Contains(unitSelectorActionNodePosition);
    
            Debug.Log($"attack position found: {attackPositionFound}");
            if(!movementPositionFound && !attackPositionFound)
            {
                Debug.Log("Condition met");
                DeselectUnit();
            }
            
        }
       UnitSelectorController.Instance.SwitchSelectorStatus();
       return false;

    }
    private bool TryHandleUnitActionMenu()
    {
        //verify if node is outside of unit movement range
        //if in range , then invoke OnActionPositionSelected to open player menu
        if(selectedUnit!=null)
        {
            
            actionPosition=UnitSelectorController.Instance.GetUnitSelectorGridPosition();
            bool movementPositionFound=selectedUnit.ValidMovementPositions.Contains(actionPosition);
            bool attackPositionFound=selectedUnit.ValidAttackPositions.Contains(actionPosition);
            if(!movementPositionFound && !attackPositionFound)
            {
                DeselectUnit();
                return true;
            }
            OnActionPositionSelected?.Invoke(this,EventArgs.Empty);
            UnitSelectorController.Instance.SetSelectorActive(false);
            return true;
        }
        return false; 

    }
    //TODO Refactor this to recieve the action name instead of the button? is cleaner but is not very readable
    public void TryHandleSelectedAction(Button button)
    {
        
        SetAction(button.name);
        Vector2 unitSelectorActionNodePosition = UnitSelectorController.Instance.GetUnitSelectorGridPosition();
        bool movementPositionFound=selectedUnit.ValidMovementPositions.Contains(unitSelectorActionNodePosition);
        bool attackPositionFound=selectedUnit.ValidAttackPositions.Contains(unitSelectorActionNodePosition);
        if(selectedUnit!=null)
        {
         
            if(movementPositionFound||attackPositionFound)
            {
                baseAction.TakeAction(unitSelectorActionNodePosition,ClearBusy);
                OnActionPositionSelected?.Invoke(this,EventArgs.Empty);
                UnitSelectorController.Instance.SetSelectorActive(true);
                OnActionTaken?.Invoke(this,EventArgs.Empty);   
            }
        }
    }
    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit=unit;
        Debug.Log(selectedUnit.GetUnitPosition());
        if(selectedUnit!=null)
        {
            SetAction("Move");
        }
        OnSelectedUnitChanged?.Invoke(this,EventArgs.Empty);
    }
    private void SetAction(string actionName)
    {
        baseAction=selectedUnit.GetAction(actionName);
    }
    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
    public void ClearBusy()
    {
        this.isBusy=false;
    }
    private void DeselectUnit()
    {
        Debug.Log("Unit deselected");
        selectedUnit=null;
        baseAction=null;
        OnDeselectedUnit?.Invoke(this,EventArgs.Empty);
    }
}
