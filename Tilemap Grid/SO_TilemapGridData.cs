using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Tilemap Grid Data", menuName="Scriptable Objects/Tilemap/Grid Data")]
public class SO_TilemapGridData : ScriptableObject
{
    [SerializeField] public int gridWidth;
    [SerializeField] public int gridHeight;
    [SerializeField] public int originX;
    [SerializeField] public int originY;
    [SerializeField] public string sceneName;
    [SerializeField] public Dictionary<Vector2, TilemapGridType> gridNodeTypes; 

}
