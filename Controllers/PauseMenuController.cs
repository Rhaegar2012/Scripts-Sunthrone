using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private List<Menu> pauseMenuList;
    [SerializeField] private int currentMenuIndex;
    [SerializeField] private TextMeshProUGUI menuNameText;
    private Menu currentMenu;
    private int menuCount;
    
   
    void OnEnable()
    {
        currentMenu=pauseMenuList[currentMenuIndex];
        currentMenu.ActivateMenu();
        menuCount=pauseMenuList.Count;
        menuNameText.text=currentMenu.MenuName;
        InputController.onMenuClosed+=InputController_ClosePauseMenu;
    }

    void OnDisable()
    {
        currentMenuIndex=0;
    }

    public void AdvanceMenu()
    {
        currentMenuIndex= currentMenuIndex+1;
        if(currentMenuIndex>=menuCount)
        {
            currentMenuIndex=0;
        }
        SwitchMenu(currentMenuIndex);
       
    }

    public void DecreaseMenu()
    {
        currentMenuIndex=currentMenuIndex-1;
        if(currentMenuIndex<0)
        {
            currentMenuIndex=0;

        }

        SwitchMenu(currentMenuIndex);

    }

    private void SwitchMenu(int menuIndex)
    {
        currentMenu.DeactivateMenu();
        currentMenu=pauseMenuList[menuIndex];
        currentMenu.ActivateMenu();
        menuNameText.text=currentMenu.MenuName;
    }

    public void InputController_ClosePauseMenu(object sender, EventArgs empty)
    {
        gameObject.SetActive(false);
    }
}
