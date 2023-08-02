using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItemManager : SingletonMonobehaviour<SceneItemManager>,ISaveable
{
    [SerializeField] private string sceneName; 
    [SerializeField] private bool gridActiveInScene;
    [SerializeField] private GameObject sceneGrid;  
    private string iSaveableUniqueID;
    private GameObjectSave gameObjectSave;
    private SceneItem[] itemsInScene;
    private List<SceneItem> sceneItemsList;
    
    //Properties
    public string ISaveableUniqueID{get{return iSaveableUniqueID;}set{iSaveableUniqueID=value;}}
    public GameObjectSave GameObjectSave {get{return gameObjectSave;}set{gameObjectSave=value;}}
    public SceneItem[] ItemsInScene {get{return itemsInScene;}set{itemsInScene=value;}}
    public List<SceneItem> SceneItemsList {get{return sceneItemsList;}set{sceneItemsList=value;}}
    public GameObject SceneGrid {get{return sceneGrid;}}

    protected override void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        base.Awake();
        GameObjectSave= new GameObjectSave();
        DontDestroyOnLoad(gameObject);
        
    }

    void Start()
    {
        BuildingSystem.onNewBuildingConstruction+=OnNewBuildingConstruction_SaveSceneState;
        LevelManager.Instance.onSceneLoaded+=OnSceneLoaded_RestoreSceneState;
        itemsInScene=GetComponentsInChildren<SceneItem>();
        sceneItemsList=new List<SceneItem>(itemsInScene);
    }

    public void OnNewBuildingConstruction_SaveSceneState(object sender, EventArgs empty)
    {
        ISaveableStoreSceneState(sceneName);
    }

    public void OnSceneLoaded_RestoreSceneState(object sender, EventArgs empty)
    { 
        gridActiveInScene=!gridActiveInScene;
        if(sceneGrid!=null)
        {
            sceneGrid.SetActive(gridActiveInScene);
        }
        ISaveableRestoreSceneState();
    }

    private void RestoreScene()
    {
        foreach(SceneItem item in itemsInScene)
        {
            item.SetActiveInScene(item.IsActiveInScene);
        }
    }
    public void ISaveableRegister()
    {
        //TODO
    }

    public void ISaveableDeregister()
    {
        //TODO
    }
    public void ISaveableStoreSceneState(string sceneName)
    {
        //clears previous save for the scene
        GameObjectSave.sceneData.Remove(sceneName);
        //Creates a new save file for the scene
        SceneSave sceneSave= new SceneSave();
        //Stores list Item information
        sceneSave.sceneItemList=new List<SceneItem>(itemsInScene);
        //Adds save data to GameObjectSave
        GameObjectSave.sceneData.Add(sceneName,sceneSave);

    }
    public void ISaveableRestoreSceneState()
    {
        
        if(LevelManager.Instance.SceneName!=sceneName)
        {  
            return;
        }
        if(GameObjectSave==null)
        {
            return;
        }
        //Call scene save with dictionary value
        if(GameObjectSave.sceneData.TryGetValue(sceneName,out SceneSave sceneSave))
        {
            if(sceneSave.sceneItemList!=null)
            {
                sceneItemsList=sceneSave.sceneItemList;
                
            }
        } 
        RestoreScene();
    }

    
    
}
