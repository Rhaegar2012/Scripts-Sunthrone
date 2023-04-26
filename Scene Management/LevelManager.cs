using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : SingletonMonobehaviour<LevelManager>
{
    //Events
    public event EventHandler onSceneLoaded;
    protected override void Awake()
    {
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
        onSceneLoaded?.Invoke(this,EventArgs.Empty);
    }

}
