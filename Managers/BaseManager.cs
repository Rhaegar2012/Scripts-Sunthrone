using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BaseManager : SingletonMonobehaviour<BaseManager>
{
    
    
    [SerializeField] private PlayerController playerPrefab;
  

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
        BuildingEntrance.onEntranceTriggered+=BuildingEntrance_InstantiatePlayerAtPosition;
    }
 
    public bool CanConstructBuilding(int buildingCost)
    {
        if(buildingCost<GameManager.Instance.Credits)
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
