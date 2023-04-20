using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : SingletonMonobehaviour<BaseManager>
{
    
    [SerializeField] private int credits;
    [SerializeField] private int influence;
    [SerializeField] private int supplies;
    public int Credits  {get{return credits;}set{credits=value;}}
    public int Influence {get{return influence;}set{influence=value;}}
    public int Supplies {get{return supplies;} set{supplies=value;}}
 
    public bool CanConstructBuilding(int buildingCost)
    {
        if(buildingCost<credits)
        {
            return true;
        }
        return false;
    }
}
