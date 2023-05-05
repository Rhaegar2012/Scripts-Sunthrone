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
    //Events 
    public static event EventHandler<string> onUnitAdded;
    public static event EventHandler<string> onUnitRemoved;

    public void UpdateShopItem(Sprite spriteImage, string nameText, int costText)
    {
        shopItemImage.sprite=spriteImage;
        shopItemNameText.text=nameText;
        shopItemCostText.text=$"{costText.ToString()}$";

    }

    public void OnAddButtonPressed()
    {
        onUnitAdded?.Invoke(this,shopItemNameText.text);
    }

    public void OnRemoveButtonPressed()
    {
        onUnitRemoved?.Invoke(this,shopItemNameText.text);
    }
   
}
