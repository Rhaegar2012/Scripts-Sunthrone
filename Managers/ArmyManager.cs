using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyManager : MonoBehaviour
{
    private List<Unit> armyUnitsList;
    private List<Unit> deployedUnitsList;
    [SerializeField] private int armySupplyLimit;
    public int ArmySupplyLimit {get{return armySupplyLimit;} set{armySupplyLimit=value;}}

    public void PurchaseUnit(Unit unit)
    {
        if(GameManager.Instance.Credits>=unit.unitCreditCost)
        {
            armyUnitsList.Add(unit);
        }
    }

    public void DeployUnit(Unit unit)
    {
        if(GameManager.Instance.Supplies>=unit.unitSupplyCost)
        {
            deployedUnitsList.Add(unit);
        }
    }

    public void DestroyUnit (Unit unit)
    {
        //TODO
    }
}
