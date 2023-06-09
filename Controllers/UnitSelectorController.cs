using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectorController : SingletonMonobehavior<UnitSelectorController>
{
    private InputActions unitSelectorInputActions;
    
    protected override void Awake()
    {
        base.Awake();
        unitSelectorInputActions=new InputActions();
        unitSelectorInputActions.UnitSelector_Base.UnitSelectorMovement.performed+=MoveSelector;
        unitSelectorInputActions.UnitSelector_Base.UnitSelectorMovement.performed+=SelectUnit;
        unitSelectorInputActions.UnitSelector_Base.UnitSelectorMovement.performed+=OpenPauseMenu;

    }


    public void MoveSelector(InputActions.CallBackContext context)
    {

    }

    public void SelectUnit (InputActions.CallBackContext context)
    {

    }

    public void OpenPauseMenu(InputActions.CallBackContext context)
    {

    }





    
}
