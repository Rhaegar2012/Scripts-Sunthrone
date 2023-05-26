using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : SingletonMonobehaviour<SaveLoadManager>
{
    [SerializeField] private string baseScene;
    [SerializeField] private float waitingTime;
    private List<GameObject> objectsActiveInSceneList= new List<GameObject>();
    private List<string> objectsInactiveInSceneList=new List<string>();
    private GameObject[] gameObjectList;


    protected override void Awake()
    {
        if(Instance!=null)
        {
            return;
        }
        base.Awake();
        DontDestroyOnLoad(gameObject);
        
    }

    void Start()
    {
        BuildingSystem.onNewBuildingConstruction+=BuildingSystem_OnNewConstruction;
        LevelManager.Instance.onSceneLoaded+=OnSceneLoaded_RestoreSceneState;

    }

    private void OnSceneLoaded_RestoreSceneState(object sender, EventArgs empty)
    {
        //TODO
    }

    

    public void BuildingSystem_OnNewConstruction(object sender, EventArgs empty)
    {
       //TODO
    }

    

    
}
