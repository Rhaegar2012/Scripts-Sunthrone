using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public enum Buildings
{
        Barracks,
        Headquarters
}

public enum UnitLevel
{
        Rookie=1,
        Seasoned=2,
        Veteran=3,
        Elite
}

public enum PlayerRank
{
        Lieutenant,
        Captain,
        Major,
        Coronel,
        General
}

public enum SceneTags
{
        ActiveInScene,
        InactiveInScene
}
public enum SceneItemType
{
        Building,
        Yard,
        Item
}

public enum BattleMedalAward
{
        NoMedal,
        Bronze,
        Silver,
        Gold
}


public enum UnitType
{
    Infantry
    //TODO    
}

public enum NodeType
{
   Grassland=1,
   Forest=2,
   Mountain=3,
   River=2,
   Road=0,
   Base=1
}
