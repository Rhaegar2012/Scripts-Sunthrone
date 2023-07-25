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

    void Start()
    {
        TurnSystem.Instance.OnTurnChanged+=TurnSystem_OnTurnChanged;
        BattleManager.Instance.OnArmyUpdate+=BattleManager_OnArmyUpdate;
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
        enemyUnitsCounterText.text=BattleManager.Instance.NumberOfEnemyUnits.ToString();
        playerUnitsCounterText.text=BattleManager.Instance.NumberOfPlayerUnits.ToString();

    }



}
