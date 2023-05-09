using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopNPC : MonoBehaviour
{
    [SerializeField] private List<Unit> availableUnitList;
    [SerializeField] private Transform shopScrollViewContent;
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private ShopItem shopItem;
    [SerializeField] private TextMeshProUGUI shopBalanceText;
    [SerializeField] private TextMeshProUGUI playerMessageText;
    private int totalCost;
    private Dictionary<string,List<Unit>> unitShopCart= new Dictionary<string,List<Unit>>(); 
    private Unit unitSelectedForPurchase;
    //Events
    public static event EventHandler OnMenuClosed;
    
    void Start()
    {
        //Initializes shop cart when scene is loaded
        totalCost=0;
        foreach(Unit unit in availableUnitList)
        {
            unitShopCart.Add(unit.UnitName,new List<Unit>());
        }
        ShopItem.onUnitAdded+=ShopItem_AddUnitToShopCart;
        ShopItem.onUnitRemoved+=ShopItem_RemoveUnitFromShopCart;
    }
    private Unit SelectUnit(string unitName)
    {
        Unit selectedUnit=availableUnitList.Find(unit=>unit.UnitName==unitName);
        return selectedUnit;
    }

    public void UpdateShopCartTotal()
    {
        totalCost=0;
        foreach(KeyValuePair<string, List<Unit>> dictionaryEntry in unitShopCart)
        {
            Unit selectedUnit=SelectUnit(dictionaryEntry.Key);
            int unitCount=dictionaryEntry.Value.Count;
            int totalUnitCost=selectedUnit.UnitCreditCost*unitCount;
            totalCost+=totalUnitCost;
        }
        shopBalanceText.text=$"Total: {totalCost}$";
    }
    public void ShopItem_AddUnitToShopCart(object sender,string unitName)
    {
        
        //find selected unit in available unit List
        Unit selectedUnit=SelectUnit(unitName);
        unitShopCart[unitName].Add(selectedUnit);
        UpdateShopCartTotal();
    }

    public void ShopItem_RemoveUnitFromShopCart(object sender,string unitName)
    {
        List<Unit> unitList=unitShopCart[unitName];
        if(unitList.Count>0)
        {
            unitList.RemoveAt(unitList.Count-1);
        }
        UpdateShopCartTotal();
    }

    public void OpenShopMenu()
    {
        shopMenu.SetActive(true);
    }

    public void DisplayAvailableUnitList()
    {
        foreach(Unit unit in availableUnitList)
        {
            shopItem.UpdateShopItem(unit.UnitSprite,unit.UnitName,unit.UnitCreditCost);
            Instantiate(shopItem,shopScrollViewContent);
        }
    }

    public void PurchaseUnitCart()
    {
        if(totalCost<=GameManager.Instance.Credits)
        {
            foreach(KeyValuePair<string, List<Unit>> unitGroup in unitShopCart)
            {
                foreach(Unit unit in unitGroup.Value)
                {
                    ArmyManager.Instance.AddUnitToArmyList(unit);
                    playerMessageText.text="Units purchased!";
                }

            }
        }
        else
        {
            playerMessageText.text="Not enough credits!";
        }
    }

    public void OnTriggerEnter2D (Collider2D other)
    {
        PlayerController.Instance.ActiveShopNPC=this;
    }

    public void OnTriggerExit2D (Collider2D other)
    {
        PlayerController.Instance.ActiveShopNPC=null;
    }

    public void QuitShop()
    {
        totalCost=0;
        foreach(KeyValuePair<string,List<Unit>> unitGroup in unitShopCart)
        {
            unitGroup.Value.Clear();
        }
        playerMessageText.text="";
        shopBalanceText.text="Total: ";
        shopMenu.SetActive(false);
        PlayerController.Instance.EnablePlayerControls();
        OnMenuClosed?.Invoke(this,EventArgs.Empty);
    }

    public void TestClick()
    {
        Debug.Log("UI Called click");
    }
}
