using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMenu : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI playerNameText;
   [SerializeField] private TextMeshProUGUI playerRankText;
   [SerializeField] private TextMeshProUGUI playerCampaignText;
   [SerializeField] private TextMeshProUGUI playerCreditText;
   [SerializeField] private TextMeshProUGUI playerSupplyText;
   [SerializeField] private TextMeshProUGUI playerInfluenceText;
   [SerializeField] private Image playerImage;

   void OnEnable()
   {
        playerNameText.text=GameManager.Instance.PlayerName;
        playerRankText.text=GameManager.Instance.PlayerRank.ToString();
        playerCampaignText.text=GameManager.Instance.PlayerCampaign;
        playerSupplyText.text=$"x{GameManager.Instance.Credits.ToString()}";
        playerSupplyText.text=$"x{GameManager.Instance.Supplies.ToString()}/{ArmyManager.Instance.ArmySupplyLimit.ToString()}";
        playerInfluenceText.text=$"x{GameManager.Instance.Influence.ToString()}";
        playerImage.sprite=GameManager.Instance.PlayerSprite;
   }

}
