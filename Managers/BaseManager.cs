using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : SingletonMonobehaviour<BaseManager>
{
    
    [SerializeField] private int credits;
    [SerializeField] private int influence;
    [SerializeField] private int supplies;
    [SerializeField] private PlayerController playerPrefab;
    public int Credits  {get{return credits;}set{credits=value;}}
    public int Influence {get{return influence;}set{influence=value;}}
    public int Supplies {get{return supplies;} set{supplies=value;}}
    //Events
    public event EventHandler onBaseStatsUpdated;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        
    }

    void Start()
    {
        onBaseStatsUpdated?.Invoke(this,EventArgs.Empty);
        BuildingEntrance.onEntranceTriggered+=BuildingEntrance_InstantiatePlayerAtPosition;
    }
 
    public bool CanConstructBuilding(int buildingCost)
    {
        if(buildingCost<credits)
        {
            return true;
        }
        return false;
    }

    public void BuildingEntrance_InstantiatePlayerAtPosition(object sender, Vector3 exitPosition)
    {
        InstantiatePlayerAtPosition(exitPosition);
    }

    private void InstantiatePlayerAtPosition(Vector3 playerSpawnPosition)
    {
        Instantiate(playerPrefab,playerSpawnPosition, Quaternion.identity);
    }
}
