using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public enum TilemapGridType
{
        Grassland,
        Forest,
        Mountain,
        River,
        Road,
        Base
}

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


