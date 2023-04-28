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
        //TODO
    }

    public void DeployUnit(Unit unit)
    {
        //TODO
    }

    public void DestroyUnit (Unit unit)
    {
        //TODO
    }
}
