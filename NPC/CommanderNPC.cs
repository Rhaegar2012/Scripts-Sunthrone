using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderNPC : MonoBehaviour
{
    [SerializeField] private GameObject battleSelectionMenu;
    [SerializeField] private List<BattleSelectionMarker> mapUIMarkers;
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
        DisplayBattleInformationMenu();
    }

    private void DisplayBattleInformationMenu()
    {
        battleSelectionMenu.SetActive(true);
        foreach(BattleSelectionMarker marker in mapUIMarkers)
        {
            SO_BattleInfo battleData=FindBattleData(marker.BattleName);
            marker.UpdateButtonIcon(battleData.awardedMedal);
        }
    }

    //Shows battle information after marker selection
    private void DisplayBattleInformation(string battleName)
    {
        //TODO
    }

    //Finds battle information from battle information list for an specific marker
    private SO_BattleInfo FindBattleData(string battleName)
    {
        SO_BattleInfo battleData= battleInformation.Find(battle=>battle.BattleName==battleName);
        return battleData;

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
