using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonobehaviour<GameManager>
{
    [SerializeField] private int credits;
    [SerializeField] private int influence;
    [SerializeField] private int supplies;
    [SerializeField] private Sprite playerSprite;
    [SerializeField] private string playerName;
    [SerializeField] private string playerCampaign;
    [SerializeField] private GameObject pauseMenu;
    //Private
    private int playerExperience;
    private PlayerRank playerRank=PlayerRank.Lieutenant;

    //Properties
    public int Credits  {get{return credits;}set{credits=value;}}
    public int Influence {get{return influence;}set{influence=value;}}
    public int Supplies {get{return supplies;} set{supplies=value;}}
    public Sprite PlayerSprite {get{return playerSprite;}set{playerSprite=value;}}
    public string PlayerName {get{return playerName;} set{playerName=value;}}
    public PlayerRank PlayerRank {get{return playerRank;}set{playerRank=value;}}
    public string PlayerCampaign {get{return playerCampaign;}set{playerCampaign=value;}}
    
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
        PlayerController.Instance.onPauseMenuCalled+=PlayerController_OpenPauseMenu;
        PlayerController.Instance.onPauseMenuClosed+=PlayerController_ClosePauseMenu;
    }

    public void PlayerController_OpenPauseMenu(object sender, EventArgs empty)
    {
        pauseMenu.SetActive(true);
    }

    public void PlayerController_ClosePauseMenu(object sender, EventArgs empty)
    {
        pauseMenu.SetActive(false);
    }





   
}
