using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ArmyUnitMenu : MonoBehaviour,IPauseMenu
{
    [SerializeField] private TextMeshProUGUI unitName;
    [SerializeField] private TextMeshProUGUI unitAttack;
    [SerializeField] private TextMeshProUGUI unitDefense;
    [SerializeField] private TextMeshProUGUI unitExperience;
    [SerializeField] private TextMeshProUGUI unitUpgradeCost;
    [SerializeField] private TextMeshProUGUI unitRank;
    [SerializeField] private Image unitImage;
    private Unit unit;
    public Unit Unit {get{return unit;}set{unit=value;}}
  

    public void DisplayUnitInfo()
    {
        unitName.text=unit.UnitName;
        unitAttack.text=unit.AttackPower.ToString();
        unitDefense.text=unit.Defense.ToString();
        unitExperience.text=unit.UnitExperience.ToString();
        unitUpgradeCost.text=unit.UnitUpgradeCost.ToString();
        unitImage.sprite=unit.UnitSprite;
        unitRank.text=unit.UnitLevel.ToString();
        
    }

    public void UpgradeUnit()
    {
        //TODO
    }

    public void DismissUnit()
    {
        //TODO
    }


}
