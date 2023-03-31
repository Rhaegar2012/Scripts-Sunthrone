using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Tilemap Grid Data", menuName="Scriptable Objects/Tilemap/Grid Data")]
public class SO_TilemapGridData : ScriptableObject
{
    public int gridWidth;
    public int gridHeight;
    public int originX;
    public int originY;
    public string sceneName;
    [SerializeField] public List<NodeProperty> nodeProperties; 

  
}
