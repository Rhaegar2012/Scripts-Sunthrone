using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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
        if(BaseManager.Instance!=null || PlayerController.Instance!=null ||LevelManager.Instance!=null)
        {
            return;
        }
        base.Awake();
        className="Base Manager";
        DontDestroyOnLoad(this.gameObject);
        InstantiatePlayerAtPosition(new Vector3(2f,-3f,0f));
        
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
        PlayerController.Instance.transform.position=exitPosition;
    }

    private PlayerController InstantiatePlayerAtPosition(Vector3 playerSpawnPosition)
    {
        //Debug.Log("Method Called");
        PlayerController playerClone=Instantiate(playerPrefab,playerSpawnPosition, Quaternion.identity).GetComponent<PlayerController>();
        return playerClone;
    }
}
