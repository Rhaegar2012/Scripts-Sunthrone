using System;
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
    [SerializeField] private Transform armyScrollViewContent;
    [SerializeField] private ArmyItem armyItemPrefab;
    private List<Unit> deployedUnitsList=new List<Unit>();
    private SO_BattleInfo battleInformation;
    private int totalDeploymentCost;
    private int maxDeploymentCost;

    void Start()
    {
        ArmyItem.OnUnitAdded+=ArmyItem_OnUnitAdded;
        ArmyItem.OnUnitRemoved+=ArmyItem_OnUnitRemoved;
    }
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
        maxDeploymentCost=battleInformation.UnitSupplyLimitForBattle;
        battleDeploymentLimitText.text=$"/:{battleInformation.UnitSupplyLimitForBattle.ToString()}";
        battleNameText.text=battleInformation.BattleName;
        battleCreditRewardText.text=$"Credits:{battleInformation.CreditReward.ToString()}";
        battleInfluenceRewardText.text=$"Influence:{battleInformation.InfluenceReward.ToString()}";
        battleSupplyRewardText.text=$"Supplies:{battleInformation.SupplyReward.ToString()}";


    }

    private void DisplayArmyUnits()
    {
        List<Unit> armyUnitList=ArmyManager.Instance.ArmyUnitsList;
        foreach(Unit unit in armyUnitList)
        {
            ArmyItem armyItem=Instantiate(armyItemPrefab,armyScrollViewContent);
            armyItem.UpdateArmyItem(unit.UnitSprite,unit.UnitName,
                                     unit.UnitLevel.ToString(),unit.UnitSupplyCost.ToString(),unit);

        }
    }

    public void StartBattle()
    {
        if(totalDeploymentCost>maxDeploymentCost)
        {
            return;
        }
        if(LevelManager.Instance!=null)
        {
            DeploySelectedUnits();
            GameManager.Instance.DisableBaseManagementFeatures();
            LevelManager.Instance.LoadScene(battleNameText.text);
        }

    }

    public void DeploySelectedUnits()
    {
        battleInformation.PlayerUnits=deployedUnitsList;
    }

    public void BackToSelectionMenu()
    {
        gameObject.SetActive(false);
    }

    public void ArmyItem_OnUnitAdded(object sender, Unit unit)
    {
        deployedUnitsList.Add(unit);
        UpdateTotalDeploymentCost();
    }

    public void ArmyItem_OnUnitRemoved(object sender, Unit unit)
    {
        deployedUnitsList.Remove(unit);
        UpdateTotalDeploymentCost();
    }

    public void UpdateTotalDeploymentCost()
    {
        totalDeploymentCost=0;
        foreach(Unit unit in deployedUnitsList)
        {
            totalDeploymentCost+=unit.UnitSupplyCost;
        }
        battleDeploymentCostText.text=$"Supplies:{totalDeploymentCost.ToString()}";
        if(totalDeploymentCost>maxDeploymentCost)
        {
            battleDeploymentCostText.color=Color.red;
        }
        else
        {
            battleDeploymentCostText.color=Color.white;
        }
    }
}
