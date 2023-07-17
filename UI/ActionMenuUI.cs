using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenuUI : MonoBehaviour
{
    [SerializeField] GameObject actionMenuButtonPanel;
    [SerializeField] Vector2 menuOffset;
    private bool isActive=false;
    void Start()
    {
        UnitActionSystem.Instance.OnActionPositionSelected+=UnitActionSystem_DisplayActionMenu;
    }

    public void UnitActionSystem_DisplayActionMenu(object sender,EventArgs empty)
    {
        isActive=!isActive;
        actionMenuButtonPanel.SetActive(isActive);
        PositionActionMenuInWorldSpace();
        
    }

    public void PositionActionMenuInWorldSpace()
    {
        Unit selectedUnit=UnitActionSystem.Instance.GetSelectedUnit();
        Vector2 selectedUnitPosition=selectedUnit.GetUnitPosition();
        Vector2 menuPosition= selectedUnitPosition+menuOffset;
        transform.position=menuPosition;
    }


}
