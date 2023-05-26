using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItemManager : SingletonMonobehaviour<SceneItemManager>,ISaveable
{
    private string iSaveableUniqueID;
    private GameObjectSave gameObjectSave;
    [SerializeField] private List<SceneItem> itemsInScene;
    [SerializeField] private string sceneName;
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
        
    }

    private void RestoreScene()
    {
        foreach(SceneItem item in itemsInScene)
        {
            if(item!=null)
            {
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
        //Call scene save with dictionary value
        if(GameObjectSave.sceneData.TryGetValue(sceneName,out SceneSave sceneSave))
        {
            if(sceneSave.sceneItemList!=null)
            {
                itemsInScene=sceneSave.sceneItemList;
                RestoreScene();
            }
        } 
    }

    
    
}
