using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyMenuDisplay : MonoBehaviour,IPauseMenu
{
    [SerializeField] private GameObject armyUnitMenuPrefab;
    [SerializeField] private Transform  armyScrollViewContent;
    [SerializeField] private int menuIndex;
    //Properties
    public int MenuIndex{get{return menuIndex;} set{menuIndex=value;}}
    
    void OnEnable()
    {
        foreach(Unit unit in ArmyManager.Instance.ArmyUnitsList)
        {
             ArmyUnitMenu unitMenuInstance= Instantiate(armyUnitMenuPrefab,armyScrollViewContent).GetComponent<ArmyUnitMenu>();
             unitMenuInstance.Unit=unit;
             unitMenuInstance.DisplayUnitInfo();
        }
    }
}
