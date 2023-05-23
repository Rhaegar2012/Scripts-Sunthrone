using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : SingletonMonobehaviour<LevelManager>
{
    private string currentSceneName;
    private Scene currentScene;
    public string SceneName{get{return currentSceneName;}set{currentSceneName=value;}}
    //Events
    public event EventHandler onSceneLoaded;
    protected override void Awake()
    {
        if(Instance!=null)
        {
            return;
        }
        base.Awake();
        className="Level Manager";
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
        currentScene=SceneManager.GetActiveScene();
        currentSceneName=sceneToLoad;
        onSceneLoaded?.Invoke(this,EventArgs.Empty);
    }

}
