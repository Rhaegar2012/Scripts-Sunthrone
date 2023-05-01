using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopNPC : MonoBehaviour
{
    [SerializeField] private List<Unit> availableUnitList;
    [SerializeField] private Transform shopScrollViewContent;
    [SerializeField] private ShopItem shopPrefab;
    private Unit unitSelectedForPurchase;
    private void AvailableDisplayUnitList()
    {
        foreach(Unit unit in availableUnitList)
        {
            shopPrefab.UpdateShopItemValues(unit.UnitSprite,unit.UnitName,unit.UnitCreditCost);
            Instantiate(shopPrefab,shopScrollViewContent);
        }
    }

    private void PurchaseUnit()
    {
        ArmyManager.Instance.PurchaseUnit(unitSelectedForPurchase);
    }
}
