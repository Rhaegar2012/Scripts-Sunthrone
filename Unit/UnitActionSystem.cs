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
        Debug.Log("Accessed Unit Selection");
        Debug.Log(UnitSelectorController.Instance.SelectionAttempt);   
        if(selectorCurrentNode.HasAnyUnit())
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
                return false;
            }
            SetSelectedUnit(nodeUnit);
            UnitSelectorController.Instance.SwitchSelectorStatus();
            return true;

        }
        Vector2 unitSelectorActionNodePosition= UnitSelectorController.Instance.GetUnitSelectorGridPosition();
        List<Vector2> validActionPositionList= selectedUnit.ValidMovementPositions;
        if(selectedUnit!=null && !validActionPositionList.Contains(unitSelectorActionNodePosition))
        {
            DeselectUnit();
            
        }
       UnitSelectorController.Instance.SwitchSelectorStatus();
       return false;

    }
    private bool TryHandleUnitActionMenu()
    {
        //verify if node is outside of unit movement range
        //if in range , then invoke OnActionPositionSelected to open player menu
        Debug.Log("Access Action Menu");
        if(selectedUnit!=null)
        {
            
            actionPosition=UnitSelectorController.Instance.GetUnitSelectorGridPosition();
            List<Vector2> validActionPositionList= selectedUnit.ValidMovementPositions;
            if(!validActionPositionList.Contains(actionPosition))
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
        List<Vector2> validActionPositionList=selectedUnit.GetValidMovementPositionList();
        if(selectedUnit!=null)
        {
         
            if(validActionPositionList.Contains(unitSelectorActionNodePosition))
            {
                Debug.Log("Selector node cleared for valid position");
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
