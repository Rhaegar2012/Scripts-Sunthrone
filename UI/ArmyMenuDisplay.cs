using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyMenuDisplay : Menu
{
    [SerializeField] private GameObject armyUnitMenuPrefab;
    [SerializeField] private Transform  armyScrollViewContent;
   
    
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
