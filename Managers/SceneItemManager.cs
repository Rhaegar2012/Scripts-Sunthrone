using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItemManager : SingletonMonobehaviour<SceneItemManager>
{
    private GameObject[] gameObjectInSceneList;
    private List<GameObject> sceneItemList;
    //Properties
    public  GameObject[] GameObjectInSceneList{get{return gameObjectInSceneList;}}
    public  List<GameObject> SceneItemList{get{return sceneItemList;}}
    protected override void Awake()
    {
        if(Instance!=null)
        {
            return;
        }
        base.Awake();
        
    }

    void Start()
    {
        gameObjectInSceneList=GameObject.FindObjectsOfType<GameObject>();
    }

    public List<GameObject> FindObjectInHierarchy(string objectName)
    {
        
        for(int i=0;i<gameObjectInSceneList.Length;i++)
        {
            Debug.Log(i);
            if(gameObjectInSceneList[i]==null)
            {
                continue;
            }
            Debug.Log($"Object in list {i} : {gameObjectInSceneList[i].name}");
        }
        return sceneItemList;

    }
}
