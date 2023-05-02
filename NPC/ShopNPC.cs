using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopNPC : MonoBehaviour
{
    [SerializeField] private List<Unit> availableUnitList;
    [SerializeField] private Transform shopScrollViewContent;
    [SerializeField] private ShopItem shopItemPrefab;
    [SerializeField] private GameObject shopMenu;
    private Unit unitSelectedForPurchase;


    public void OpenShopMenu()
    {
        shopMenu.SetActive(true);
    }

    public void DisplayAvailableUnitList()
    {
        foreach(Unit unit in availableUnitList)
        {
            shopItemPrefab.UpdateShopItemValues(unit.UnitSprite,unit.UnitName,unit.UnitCreditCost);
            Instantiate(shopItemPrefab,shopScrollViewContent);
        }
    }

    public void PurchaseUnit()
    {
        ArmyManager.Instance.PurchaseUnit(unitSelectedForPurchase);
    }

    public void OnTriggerEnter2D (Collider2D other)
    {
        PlayerController.Instance.ActiveShopNPC=this;
    }

    public void OnTriggerExit2D (Collider2D other)
    {
        PlayerController.Instance.ActiveShopNPC=null;
    }
}
