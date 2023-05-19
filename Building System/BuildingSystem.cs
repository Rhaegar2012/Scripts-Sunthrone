using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] private GameObject constructionYard;
    [SerializeField] private GameObject newBuilding;
    [SerializeField] private string buildingName;
    [SerializeField] private int buildingCost;
    public GameObject ConstructionYard{get{return constructionYard;}}
    public GameObject NewBuilding {get{return newBuilding;}}
    public string BuildingName {get{return buildingName;}}
    public int BuildingCost {get{return buildingCost;}}
    //Events
    public static event EventHandler onNewBuildingConstruction; 


    

    public void ConstructNewBuilding()
    {
        constructionYard.SetActive(false);
        newBuilding.SetActive(true);
        onNewBuildingConstruction?.Invoke(this,EventArgs.Empty);
        gameObject.SetActive(false);
        

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
