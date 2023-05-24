using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : SingletonMonobehaviour<SaveLoadManager>
{
    [SerializeField] private string baseScene;
    [SerializeField] private float waitingTime;
    private List<SceneItem> objectsActiveInSceneList= new List<SceneItem>();
    private List<SceneItem> objectsInactiveInSceneList=new List<SceneItem>();
    private SceneItem[] sceneItems;
    private GameObject[] gameObjectList;


    protected override void Awake()
    {
        if(Instance!=null)
        {
            return;
        }
        base.Awake();
        DontDestroyOnLoad(gameObject);
        gameObjectList = GameObject.FindObjectsOfType<GameObject>();
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
        sceneItems=FindObjectsOfType<SceneItem>();
        Transform testTransform=transform.Find("Barracks");
        gameObjectList = GameObject.FindObjectsOfType<GameObject>();
        
        Debug.Log(testTransform);
        

        if(LevelManager.Instance.SceneName==baseScene)
        {
            Debug.Log("Accessed");
            foreach(SceneItem item in objectsActiveInSceneList)
            {
                
            }
            foreach(SceneItem item in objectsInactiveInSceneList)
            {
                
            }
        }
    }

    

    public void BuildingSystem_OnNewConstruction(object sender, EventArgs empty)
    {
        BuildingSystem constructionSign= (BuildingSystem) sender;
        UpdateObjectActivationLists(constructionSign.NewBuilding,constructionSign.ConstructionYard);

    }

    public void UpdateObjectActivationLists (SceneItem objectActivated, SceneItem objectDeactivated)
    {
        objectsActiveInSceneList.Add(objectActivated);
        objectsInactiveInSceneList.Add(objectDeactivated);

    }

    
}
