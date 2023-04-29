using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExteriorUI : MonoBehaviour
{
    [SerializeField] private GameObject popUpMessage;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private TextMeshProUGUI supplyText,creditsText,influenceText;
    //Events
    public static event EventHandler onPopUpMessageCalled;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateResourceDisplay();
        PlayerController.Instance.onPopupCalled+=PlayerController_DisplayConstructionMessage;
        GameManager.Instance.onGameStatsUpdated+=GameManager_UpdateGameStats;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateResourceDisplay()
    {
        supplyText.text=GameManager.Instance.Supplies.ToString();
        creditsText.text=GameManager.Instance.Credits.ToString();
        influenceText.text=GameManager.Instance.Influence.ToString();
    }

    public void PlayerController_DisplayConstructionMessage(object sender, BuildingSystem buildingSign)
    {
        popUpMessage.SetActive(true);
        onPopUpMessageCalled?.Invoke(this,EventArgs.Empty);
        messageText.text=$"Construct {buildingSign.BuildingName} for {buildingSign.BuildingCost} credits";
    }

    public void GameManager_UpdateGameStats(object sender, EventArgs empty)
    {
        UpdateResourceDisplay();
    }

    public void ConstructBuilding()
    {
        int buildingCost= PlayerController.Instance.ActiveConstructionSign.BuildingCost;
        if(GameManager.Instance.Credits>=buildingCost)
        {
            PlayerController.Instance.ActiveConstructionSign.ConstructNewBuilding();
            GameManager.Instance.Credits-=buildingCost;
            UpdateResourceDisplay();
        }
        popUpMessage.SetActive(false);

    }
}
