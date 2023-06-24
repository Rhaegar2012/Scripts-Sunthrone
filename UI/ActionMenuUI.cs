using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenuUI : MonoBehaviour
{
    [SerializeField] GameObject actionMenuButtonPanel;

    void Start()
    {
        UnitActionSystem.Instance.OnActionPositionSelected+=UnitActionSystem_DisplayActionMenu;
    }

    public void UnitActionSystem_DisplayActionMenu(object sender, EventArgs empty)
    {
        actionMenuButtonPanel.SetActive(false);
    }


}
