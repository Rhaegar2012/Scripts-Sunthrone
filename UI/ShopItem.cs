using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem:MonoBehaviour
{
    [SerializeField] private Image shopItemImage;
    [SerializeField] private TextMeshProUGUI shopItemNameText;
    [SerializeField] private TextMeshProUGUI shopItemCostText;
    [SerializeField] private TextMeshProUGUI shopItemQuantityText;
    private int unitShopQuantity; 
    public int UnitShopQuantity{get{return unitShopQuantity;}set{unitShopQuantity=value;}}
    //Events 
    public static event EventHandler<string> onUnitAdded;
    public static event EventHandler<string> onUnitRemoved;

    public void UpdateShopItem(Sprite spriteImage, string nameText, int costText)
    {
        shopItemImage.sprite=spriteImage;
        shopItemNameText.text=nameText;
        unitShopQuantity=0;
        shopItemCostText.text=$"{costText.ToString()}$";
    }

    public void ResetShopItemQuantityText()
    {
        shopItemQuantityText.text="";
    }

    public void OnAddButtonPressed()
    {
        unitShopQuantity+=1;
        shopItemQuantityText.text=$"x{unitShopQuantity}";
        onUnitAdded?.Invoke(this,shopItemNameText.text);
    }

    public void OnRemoveButtonPressed()
    {
        if(unitShopQuantity>0)
        {
            unitShopQuantity-=1;
            shopItemQuantityText.text=$"x{unitShopQuantity}";
        }
        else
        {
            unitShopQuantity=0;
            shopItemQuantityText.text="";
        }
        onUnitRemoved?.Invoke(this,shopItemNameText.text);
    }
   
}
