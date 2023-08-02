using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleInformationUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI turnText;
    [SerializeField] private TextMeshProUGUI enemyUnitsCounterText;
    [SerializeField] private TextMeshProUGUI playerUnitsCounterText;
    [SerializeField] private TextMeshProUGUI popUpMessageText;
    [SerializeField] private GameObject popUpMessage;


    void Start()
    {
        TurnSystem.Instance.OnTurnChanged+=TurnSystem_OnTurnChanged;
        BattleManager.Instance.OnArmyUpdate+=BattleManager_OnArmyUpdate;
        BattleManager.Instance.OnBattleFinished+=BattleManager_OnBattleFinished;
        UpdateArmySizeTexts();
    }

    public void TurnSystem_OnTurnChanged(object sender, EventArgs empty)
    {
        if(TurnSystem.Instance.IsPlayerTurn())
        {
            turnText.text="PLAYER";
        }
        else
        {
            turnText.text="ENEMY";
        }

    }

    public void BattleManager_OnArmyUpdate(object sender, EventArgs empty)
    {
        UpdateArmySizeTexts();
    }

    public void UpdateArmySizeTexts()
    {
        enemyUnitsCounterText.text=$"Enemy Units: {BattleManager.Instance.NumberOfEnemyUnits.ToString()}";
        playerUnitsCounterText.text=$"Player Units: {BattleManager.Instance.NumberOfPlayerUnits.ToString()}";

    }

    public void BattleManager_OnBattleFinished(object sender,string message)
    {
        popUpMessage.SetActive(true);
        popUpMessageText.text=message;
    }



}
