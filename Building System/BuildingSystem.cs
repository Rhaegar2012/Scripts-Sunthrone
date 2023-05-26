using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] private SceneItem constructionYard;
    [SerializeField] private SceneItem newBuilding;
    [SerializeField] private string buildingName;
    [SerializeField] private int buildingCost;
    public SceneItem ConstructionYard{get{return constructionYard;}}
    public SceneItem NewBuilding {get{return newBuilding;}}
    public string BuildingName {get{return buildingName;}}
    public int BuildingCost {get{return buildingCost;}}
    //Events
    public static event EventHandler onNewBuildingConstruction; 


    

    public void ConstructNewBuilding()
    {
        constructionYard.SetActiveInScene(false);
        newBuilding.SetActiveInScene(true);
        Destroy(gameObject);
        gameObject.SetActive(false);
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
