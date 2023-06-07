using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderNPC : MonoBehaviour
{
    [SerializeField] private GameObject battleSelectionMenu;
    [SerializeField] private GameObject battleInformationMenu;
    [SerializeField] private List<BattleSelectionMarker> mapUIMarkers;
    private List<SO_BattleInfo> battleInformation;
    private List<Unit> availableUnits;
    //Events


    void Start()
    {
        battleInformation=GameManager.Instance.BattleInformation;
        availableUnits=ArmyManager.Instance.ArmyUnitsList;
        //Event subscription
        PlayerController.Instance.onCommandMenuCalled+=PlayerController_OnCommandMenuCalled;
        InputController.onMenuClosed+=InputController_CloseMenu;
    }

    private void PlayerController_OnCommandMenuCalled(object sender,EventArgs empty)
    {
        battleSelectionMenu.SetActive(true);
        UpdateBattleInformationMenu();
    }

    private void UpdateBattleInformationMenu()
    {
        battleSelectionMenu.SetActive(true);
        foreach(BattleSelectionMarker marker in mapUIMarkers)
        {
            SO_BattleInfo battleData=FindBattleData(marker.BattleName);
            marker.UpdateButtonIcon(battleData.awardedMedal);
        }
    }
    
    //Shows battle information after marker selection
    private void DisplayBattleInformation(string selectedBattle)
    {
        BattleInformationMenu battleInformation=battleInformationMenu.GetComponent<BattleInformationMenu>();
        SO_BattleInfo battleData=FindBattleData(selectedBattle);
        battleInformation.UpdateBattleInformation(battleData);
    }

    //Finds battle information from battle information list for an specific marker
    private SO_BattleInfo FindBattleData(string battleName)
    {
        SO_BattleInfo battleData= battleInformation.Find(battle=>battle.BattleName==battleName);
        return battleData;

    }

    //Menu Button methods 
    public void ActivateBattleMenu(string battleName)
    {
        battleInformationMenu.SetActive(true);
        DisplayBattleInformation(battleName);
    }

    public void CloseBattleInformationMenu()
    {
        battleInformationMenu.SetActive(false);
        battleSelectionMenu.SetActive(true);
    }
    //External events
    public void InputController_CloseMenu(object sender, EventArgs empty)
    {
        if(battleSelectionMenu!=null)
        {
            battleSelectionMenu.SetActive(false);
        }
        
    }

    public void StartBattle()
    {
        //TODO
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
