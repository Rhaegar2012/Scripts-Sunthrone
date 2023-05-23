using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : SingletonMonobehaviour<SaveLoadManager>
{
    [SerializeField] private string baseScene;
    [SerializeField] private float waitingTime;
    private List<string> objectsActiveInSceneList= new List<string>();
    private List<string> objectsInactiveInSceneList=new List<string>();


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
        Debug.Log("OnSceneLoaded_RestoreSceneState");
        Debug.Log($"Scene name {LevelManager.Instance.SceneName}");
        if(LevelManager.Instance.SceneName==baseScene)
        {
            Debug.Log("Accessed");
            foreach(string objectName in objectsActiveInSceneList)
            {
                
            }
            foreach(string objectName in objectsInactiveInSceneList)
            {
                
            }
        }
    }

    

    public void BuildingSystem_OnNewConstruction(object sender, EventArgs empty)
    {
        BuildingSystem constructionSign= (BuildingSystem) sender;
        UpdateObjectActivationLists(constructionSign.NewBuilding,constructionSign.ConstructionYard);

    }

    public void UpdateObjectActivationLists (GameObject objectActivated, GameObject objectDeactivated)
    {
        objectsActiveInSceneList.Add(objectActivated.name);
        objectsInactiveInSceneList.Add(objectDeactivated.name);

    }

    
}
