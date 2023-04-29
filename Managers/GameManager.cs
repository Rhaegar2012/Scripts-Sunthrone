using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonobehaviour<GameManager>
{
    [SerializeField] private int credits;
    [SerializeField] private int influence;
    [SerializeField] private int supplies;
    public int Credits  {get{return credits;}set{credits=value;}}
    public int Influence {get{return influence;}set{influence=value;}}
    public int Supplies {get{return supplies;} set{supplies=value;}}
    //Events
    public event EventHandler onGameStatsUpdated;
    protected override void Awake()
    {
        if(GameManager.Instance!=null)
        {
            return;
        }
        base.Awake();
        className="Game Manager";
        DontDestroyOnLoad(this.gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        onGameStatsUpdated?.Invoke(this,EventArgs.Empty);
    }

   
}
