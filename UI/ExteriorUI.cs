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
    void Awake()
    {
        PlayerController.Instance.onPopupCalled+=PlayerController_DisplayConstructionMessage;
    }
    // Start is called before the first frame update
    void Start()
    {

        
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
        messageText.text=$"Construct {buildingSign.BuildingName} for {buildingSign.BuildingCost} credits";
    }

    public void ConstructBuilding(int buildingCost, string buildingName)
    {
        
        if(BaseManager.Instance.Credits>=buildingCost)
        {
            PlayerController.Instance.ActiveConstructionSign.ConstructNewBuilding();
        }

    }
}
