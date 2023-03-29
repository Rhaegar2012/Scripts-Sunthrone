using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid_Testing : MonoBehaviour
{
   
    void Start()
    {
        LevelGridDescriptors();
        
    }

    private void LevelGridDescriptors()
    {
        Debug.Log($"Level Grid Height {LevelGrid.Instance.GetTilemapHeight().ToString()}");
        Debug.Log($"Level Grid Width {LevelGrid.Instance.GetTilemapWidth().ToString()}");
        Debug.Log($"Level Grid Tilemap Origin {LevelGrid.Instance.GetTilemapOrigin().ToString()}");
    }
}
