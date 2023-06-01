using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderNPC : MonoBehaviour
{
    [SerializeField] private GameObject battleSelectionMenu;
    [SerializeField] private List<GameObject> mapUIMarkers;
    private SO_BattleInfo selectedBattle;
    private List<SO_BattleInfo> battleInformation;
    private List<Unit> availableUnits;

    void Start()
    {
        battleInformation=GameManager.Instance.BattleInformation;
        availableUnits=ArmyManager.Instance.ArmyUnitsList;
        //Event subscription
        PlayerController.Instance.onCommandMenuCalled+=PlayerController_OnCommandMenuCalled;
    }

    private void PlayerController_OnCommandMenuCalled(object sender,EventArgs empty)
    {
        battleSelectionMenu.SetActive(true);
        DisplayBattleInformationMenu()
    }

    private void DisplayBattleInformationMenu()
    {

    }

    private void DisplayBattleInformation(string battleName)
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController.Instance.ActiveCommanderNPC=this;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        PlayerController.Instance.ActiveCommanderNPC=null;
    }

}
