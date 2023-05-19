using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : SingletonMonobehaviour<SaveLoadManager>
{
    [SerializeField] string baseScene;
    private List<GameObject> objectsActiveInSceneList;
    private List<GameObject> objectsInactiveInSceneList;


    protected override void Awake()
    {
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
        if(LevelManager.Instance.SceneName==baseScene)
        {
            foreach(GameObject gameObject in objectsActiveInSceneList)
            {
                gameObject.SetActive(true);
            }
            foreach(GameObject gameObject in objectsInactiveInSceneList)
            {
                gameObject.SetActive(false);
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
        objectsActiveInSceneList.Add(objectActivated);
        objectsInactiveInSceneList.Add(objectDeactivated);

    }

    
}
