using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : SingletonMonobehaviour<BaseManager>
{
    
    [SerializeField] private int credits;
    public int Credits  {get{return credits;}set{credits=value;}}
 
    public bool CanConstructBuilding(int buildingCost)
    {
        if(buildingCost<credits)
        {
            return true;
        }
        return false;
    }
}
