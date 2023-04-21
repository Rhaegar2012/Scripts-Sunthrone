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
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.Instance.onPopupCalled+=PlayerController_DisplayConstructionMessage;
        BaseManager.Instance.onBaseStatsUpdated+=BaseManager_UpdateBaseStats;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateResourceDisplay()
    {
        supplyText.text=BaseManager.Instance.Supplies.ToString();
        creditsText.text=BaseManager.Instance.Credits.ToString();
        influenceText.text=BaseManager.Instance.Influence.ToString();
    }

    public void PlayerController_DisplayConstructionMessage(object sender, BuildingSystem buildingSign)
    {
        popUpMessage.SetActive(true);
        onPopUpMessageCalled?.Invoke(this,EventArgs.Empty);
        messageText.text=$"Construct {buildingSign.BuildingName} for {buildingSign.BuildingCost} credits";
    }

    public void BaseManager_UpdateBaseStats(object sender, EventArgs empty)
    {
        supplyText.text=BaseManager.Instance.Supplies.ToString();
        creditsText.text=BaseManager.Instance.Credits.ToString();
        influenceText.text=BaseManager.Instance.Influence.ToString();
    }

    public void ConstructBuilding()
    {
        int buildingCost= PlayerController.Instance.ActiveConstructionSign.BuildingCost;
        if(BaseManager.Instance.Credits>=buildingCost)
        {
            PlayerController.Instance.ActiveConstructionSign.ConstructNewBuilding();
            BaseManager.Instance.Credits-=buildingCost;
            UpdateResourceDisplay();
        }
        popUpMessage.SetActive(false);

    }
}
