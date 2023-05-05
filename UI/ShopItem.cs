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

    public void UpdateShopItem(Sprite spriteImage, string nameText, int costText)
    {
        shopItemImage.sprite=spriteImage;
        shopItemNameText.text=nameText;
        shopItemCostText.text=costText.ToString();

    }
   
}
