using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItemManager : SingletonMonobehaviour<SceneItemManager>,ISaveable
{
    private string iSaveableUniqueID;
    private GameObjectSave gameObjectSave;
    [SerializeField] private List<SceneItem> itemsInScene;
    [SerializeField] private string sceneName;
    [SerializeField] Transform buildingTransform;
   
    //Properties
    public string ISaveableUniqueID{get{return iSaveableUniqueID;}set{iSaveableUniqueID=value;}}
    public GameObjectSave GameObjectSave {get{return gameObjectSave;}set{gameObjectSave=value;}}

    

    protected override void Awake()
    {
        if(Instance!=null)
        {
            return;
        }
        base.Awake();
        GameObjectSave= new GameObjectSave();
        
    }

    void Start()
    {
        BuildingSystem.onNewBuildingConstruction+=OnNewBuildingConstruction_SaveSceneState;
        LevelManager.Instance.onSceneLoaded+=OnSceneLoaded_RestoreSceneState;
    }

    public void OnNewBuildingConstruction_SaveSceneState(object sender, EventArgs empty)
    {
        ISaveableStoreSceneState(sceneName);
    }

    public void OnSceneLoaded_RestoreSceneState(object sender, EventArgs empty)
    {
        
        ISaveableRestoreSceneState();
    }

    public void AddSceneItem(SceneItem item)
    {
        itemsInScene.Add(item);
    }

    private void RestoreScene()
    {
        
        
        foreach(SceneItem item in itemsInScene)
        {
            Debug.Log($"Item {item}");
            if(item!=null)
            {
                Debug.Log("Accessed");
                item.SetActiveInScene();
            }
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
        sceneSave.sceneItemList=itemsInScene;
        //Adds save data to GameObjectSave
        GameObjectSave.sceneData.Add(sceneName,sceneSave);

    }
    public void ISaveableRestoreSceneState()
    {
        if(LevelManager.Instance.SceneName!=sceneName)
        {
            return;
        }
        //Call scene save with dictionary value
        if(GameObjectSave.sceneData.TryGetValue(sceneName,out SceneSave sceneSave))
        {
            if(sceneSave.sceneItemList!=null)
            {
                Debug.Log(sceneSave.sceneItemList.Count);
                List<SceneItem> itemsInScene=sceneSave.sceneItemList;
                foreach(SceneItem item in itemsInScene)
                {
                    Debug.Log($"Scene Item name {item.ItemName}");
                    Debug.Log($"Scene Item State {item.IsActiveInScene}");
                    
                    Debug.Log($"Scene Item parent {item.ParentTransform}");
                    Instantiate(item.ItemPrefab,transform);
                }
                //RestoreScene();
            }
        } 
    }

    
    
}
