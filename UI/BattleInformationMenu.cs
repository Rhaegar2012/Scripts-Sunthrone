using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleInformationMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI battleDeploymentCostText;
    [SerializeField] private TextMeshProUGUI battleDeploymentLimitText;
    [SerializeField] private TextMeshProUGUI battleNameText;
    [SerializeField] private TextMeshProUGUI battleCreditRewardText;
    [SerializeField] private TextMeshProUGUI battleInfluenceRewardText;
    [SerializeField] private TextMeshProUGUI battleSupplyRewardText;
    private SO_BattleInfo battleInformation;


    void OnEnable()
    {
        UpdateBattleInformation();
        DisplayArmyUnits();
    }

    //Method to be called from battle markers in campaign menu
    public void SetBattleInfo(SO_BattleInfo battleInfo)
    {
        battleInformation=battleInfo;
    }

    public void UpdateBattleInformation()
    {
        battleDeploymentLimitText.text=battleInformation.UnitSupplyLimitForBattle.ToString();
        battleNameText.text=battleInformation.BattleName;
        battleCreditRewardText.text=battleInformation.CreditReward.ToString();
        battleInfluenceRewardText.text=battleInformation.InfluenceReward.ToString();
        battleSupplyRewardText.text=battleInformation.SupplyReward.ToString();

    }

    private void DisplayArmyUnits()
    {
        //TODO
    }

    public void StartBattle()
    {
        if(LevelManager.Instance!=null)
        {
            LevelManager.Instance.LoadScene(battleNameText.text);
        }

    }

    public void BackToSelectionMenu()
    {
        gameObject.SetActive(false);
    }
}
