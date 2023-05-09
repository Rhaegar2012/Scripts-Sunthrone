using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyManager : SingletonMonobehaviour<ArmyManager>
{
    private List<Unit> armyUnitsList=new List<Unit>();
    private List<Unit> deployedUnitsList=new List<Unit>();
    [SerializeField] private int armySupplyLimit;
    public int ArmySupplyLimit {get{return armySupplyLimit;} set{armySupplyLimit=value;}}
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    public void AddUnitToArmyList(Unit unit)
    {
        armyUnitsList.Add(unit);   
    }

    public void DeployUnit(Unit unit)
    {
        if(GameManager.Instance.Supplies>=unit.UnitSupplyCost)
        {
            deployedUnitsList.Add(unit);
        }
    }

    public void DestroyUnit (Unit unit)
    {
        //TODO
    }
}
