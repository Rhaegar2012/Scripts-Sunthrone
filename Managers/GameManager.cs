using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonobehaviour<GameManager>
{
    [Header("Player Info")]
    [SerializeField] private int credits;
    [SerializeField] private int influence;
    [SerializeField] private int supplies;
    [SerializeField] private Sprite playerSprite;
    [SerializeField] private string playerName;
    [SerializeField] private string playerCampaign;
    [SerializeField] private GameObject pauseMenu;
    [Header("Battle Info")]
    [SerializeField] private List<SO_BattleInfo> battleInformation;
    [Header("Base grid Info")]
    [SerializeField] private GameObject baseTilemapGrid;
    


    //Private
    private int playerExperience;
    private GameObject pauseMenuInstance;
    private PlayerRank playerRank=PlayerRank.Lieutenant;
    private PlayerController playerInstance;
    private SceneItemManager baseExteriorGrid;

    //Properties
    public int Credits  {get{return credits;}set{credits=value;}}
    public int Influence {get{return influence;}set{influence=value;}}
    public int Supplies {get{return supplies;} set{supplies=value;}}
    public Sprite PlayerSprite {get{return playerSprite;}set{playerSprite=value;}}
    public string PlayerName {get{return playerName;} set{playerName=value;}}
    public PlayerRank PlayerRank {get{return playerRank;}set{playerRank=value;}}
    public string PlayerCampaign {get{return playerCampaign;}set{playerCampaign=value;}}
    public List<SO_BattleInfo> BattleInformation {get{return battleInformation;}}
    
    //Events
    public event EventHandler onGameStatsUpdated;
    protected override void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(GameManager.Instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        base.Awake();
        className="Game Manager";
        pauseMenuInstance=Instantiate(pauseMenu,transform);
        pauseMenuInstance.SetActive(false);
        PlayerController.Instance.EnablePlayerControls();
        playerInstance=FindObjectOfType<PlayerController>();
        baseExteriorGrid=FindObjectOfType<SceneItemManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        onGameStatsUpdated?.Invoke(this,EventArgs.Empty);
        PlayerController.Instance.onPauseMenuCalled+=PlayerController_OpenPauseMenu;
        LevelManager.Instance.onSceneLoaded+=LevelManager_OnSceneLoaded;
    }

    public void LevelManager_OnSceneLoaded(object sender, EventArgs empty)
    {
        if(pauseMenu==null)
        {
            pauseMenu=FindObjectOfType<PauseMenuController>().gameObject;
        }
        
    }

    public void PlayerController_OpenPauseMenu(object sender, EventArgs empty)
    {
        
        if(pauseMenuInstance.activeInHierarchy)
        {
            pauseMenuInstance.SetActive(false);
        }
        else
        {
            pauseMenuInstance.SetActive(true);
        }
        
    }

    public void SetUpBattleScene()
    {
        DisableBaseManagementFeatures();

    }

    public void DisableBaseManagementFeatures()
    {
        playerInstance.gameObject.SetActive(false);
        baseExteriorGrid.gameObject.SetActive(false);
    }
    public void EnableBaseManagementFeatures()
    {
        playerInstance.gameObject.SetActive(true);
        baseExteriorGrid.gameObject.SetActive(true);
        baseTilemapGrid.SetActive(true);
    }

   





   
}
