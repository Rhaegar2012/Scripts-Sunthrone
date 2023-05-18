using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    private List<GameObject> objectActiveInScene;
    private List<GameObject> objectInactiveInScene;


    void Awake()
    {
        RestoreSceneState();

    }

    void Start()
    {

    }

    private void RestoreSceneState()
    {

    }

    public void UpdateObjectActivationLists ()
    {
        //TODO
    }

    
}
