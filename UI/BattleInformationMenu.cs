using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleInformationMenu : MonoBehaviour
{
    [SerializeField] private Image battleImage;
    [SerializeField] private TextMeshProUGUI influenceRewardText;
    [SerializeField] private TextMeshProUGUI suppliesRewardText;
    [SerializeField] private TextMeshProUGUI creditsRewardText;
    [SerializeField] private TextMeshProUGUI battleNameText;
    

    public void UpdateBattleInformation(SO_BattleInfo battleInformation)
    {
        influenceRewardText.text=$"x{battleInformation.InfluenceReward.ToString()}";
        suppliesRewardText.text=$"x{battleInformation.SupplyReward.ToString()}";
        creditsRewardText.text=$"x{battleInformation.CreditReward.ToString()}";
        battleNameText.text=battleInformation.BattleName;
        battleImage.sprite=battleInformation.BattleEnvironmentSprite;
    } 
}
