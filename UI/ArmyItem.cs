using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArmyItem : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI unitNameText;
   [SerializeField] private TextMeshProUGUI unitSupplyCostText;
   [SerializeField] private TextMeshProUGUI unitLevelText;
   [SerializeField] private Image unitImage;
   private Unit unit;

   //Events
   public static event EventHandler<Unit> OnUnitAdded;
   public static event EventHandler<Unit> OnUnitRemoved;

   public void UpdateArmyItem(Sprite unitSprite, string unitName , string unitLevel, 
                              string unitSupplyCost,Unit itemUnit)
   {
        unitNameText.text=unitName;
        unitSupplyCostText.text=unitSupplyCost;
        unitLevelText.text=unitLevel;
        unitImage.sprite=unitSprite;
        unit=itemUnit;
   }

   public void AddUnit()
   {
      OnUnitAdded?.Invoke(this, unit);
   }

   public void RemoveUnit()
   {
      OnUnitRemoved?.Invoke(this,unit);
   }
}
