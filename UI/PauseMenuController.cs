using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private List<IPauseMenu> pauseMenuList;
    [SerializeField] private int currentMenuIndex;
    private IPauseMenu currentMenu;
    private int menuCount;

    void OnEnable()
    {
        currentMenu=pauseMenuList[currentMenuIndex];
        //TODO Implement an active method in the interface so it can be called
        //currentMenu.SetActive(true);
    }
}
