using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : SingletonMonobehaviour<CameraController>
{
    private CinemachineVirtualCamera sceneCamera;
    private PlayerController player;
    protected override void Awake()
    {
        base.Awake();
        className="Camera Manager";
    }
    
    // Start is called before the first frame update
    void Start()
    {
        sceneCamera=FindObjectOfType<CinemachineVirtualCamera>();
        player=FindObjectOfType<PlayerController>();
        if(player!=null)
        {
            sceneCamera.Follow=player.transform;
        }
        
        LevelManager.Instance.onSceneLoaded+=LevelManager_OnSceneLoaded;
    }

    public void LevelManager_OnSceneLoaded(object sender, EventArgs empty)
    {
        sceneCamera=FindObjectOfType<CinemachineVirtualCamera>();
        player=FindObjectOfType<PlayerController>();
        if(player!=null)
        {
            sceneCamera.Follow=player.transform;
        }
        

    }

    public void UpdateFollowingUnit(Transform transform)
    {
        sceneCamera.Follow=transform;
    }

}
