using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyManager : SingletonMonobehaviour<ArmyManager>
{
    [SerializeField] private int armySupplyLimit;
    private List<Unit> armyUnitsList=new List<Unit>();
    private Unit selectedUnit;
    //Properties
    public int ArmySupplyLimit {get{return armySupplyLimit;} set{armySupplyLimit=value;}}
    public List<Unit> ArmyUnitsList {get{return armyUnitsList;} set{armyUnitsList=value;}}
    public Unit SelectedUnit {get{return selectedUnit;}}
    
    
    protected override void Awake()
    {
        if(Instance!=null)
        {
            return;
        }
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    public void AddUnitToArmyList(Unit unit)
    {
        armyUnitsList.Add(unit);   
    }

    public void DestroyUnit (Unit unit)
    {
        //TODO
    }
}
