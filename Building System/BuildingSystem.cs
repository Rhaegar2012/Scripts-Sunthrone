using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] private SceneItem constructionYard;
    [SerializeField] private SceneItem newBuilding;
    [SerializeField] private SceneItem constructionSign;
    [SerializeField] private string buildingName;
    [SerializeField] private int buildingCost;
    [SerializeField] private Transform buildingParentTransform;
    public SceneItem ConstructionYard{get{return constructionYard;}}
    public SceneItem NewBuilding {get{return newBuilding;}}
    public string BuildingName {get{return buildingName;}}
    public int BuildingCost {get{return buildingCost;}}
    //Events
    public static event EventHandler onNewBuildingConstruction; 


    

    public void ConstructNewBuilding()
    {
        constructionYard.SetActiveInScene(false);
        constructionSign.SetActiveInScene(false);
        newBuilding.SetActiveInScene(true);
        onNewBuildingConstruction?.Invoke(this,EventArgs.Empty);   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController.Instance.ActiveConstructionSign=this;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerController.Instance.ActiveConstructionSign=null;
    }
}
