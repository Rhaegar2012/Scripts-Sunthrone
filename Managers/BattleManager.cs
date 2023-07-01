using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : SingletonMonobehaviour<BattleManager>
{
    [SerializeField] private SO_BattleInfo battleInformation;
    [SerializeField] private List<Unit> enemyUnitList;
    [SerializeField] private List<Vector2> enemyUnitPositionList;
    [SerializeField] private List<Vector2> playerUnitSpawnPointList;
    private int numberOfPlayerUnits;
    private List<Unit> playerUnitList;
    private List<Unit> currentArmyList;
    // Start is called before the first frame update
    void Start()
    {
        numberOfPlayerUnits=battleInformation.GetNumberOfPlayerUnits();
        playerUnitList=battleInformation.GetPlayerUnitList();
        currentArmyList=playerUnitList;
        PlacePlayerUnits();
        PlaceEnemyUnits();
        
        
    }

    // Switch turn if all the units in the current army have completed their actions
    void Update()
    {
        foreach(Unit unit in currentArmyList)
        {
            if(!unit.UnitCompletedAction())
            {
                return;
            }
        }
        SwitchTurn();
    }

    public void PlacePlayerUnits()
    {
        if(playerUnitSpawnPointList.Count<playerUnitList.Count)
        {
            int difference=playerUnitList.Count-playerUnitSpawnPointList.Count;
            CreateNewPlayerSpawnPoints(difference);
        }
        //Instantiates Player Units and stores them in the level grid
        for(int i=0; i<playerUnitList.Count;i++)
        {
            Unit newUnit =Instantiate(playerUnitList[i],playerUnitSpawnPointList[i],Quaternion.identity);
            TilemapGridNode unitNode=LevelGrid.Instance.GetNodeAtPosition(playerUnitSpawnPointList[i]);
            newUnit.CurrentNode=unitNode;
            newUnit.GridPosition=newUnit.CurrentNode.GetGridPosition();
            LevelGrid.Instance.SetUnitAtGridNode(playerUnitSpawnPointList[i],newUnit);
        }

    }

    public void PlaceEnemyUnits()
    {
        for(int i=0; i<enemyUnitList.Count;i++)
        {
            LevelGrid.Instance.SetUnitAtGridNode(enemyUnitPositionList[i],enemyUnitList[i]);
        }
    }

    public void CreateNewPlayerSpawnPoints(int numberOfPositionsRequired)
    {
        Vector2 lastSpawnPointInList= playerUnitSpawnPointList[playerUnitSpawnPointList.Count-1];
        Vector2 offsetPosition= new Vector2(0f,0f);
        for(int i=0;i<numberOfPositionsRequired;i++)
        {
            //if i is an even number offset in x , if is an odd number offset in y
            if(i%2==0)
            {
                offsetPosition= lastSpawnPointInList+new Vector2(1f,0f);
            }
            else
            {
                offsetPosition=lastSpawnPointInList+ new Vector2(0f,1f);
            }
            //Checks if there is a unit in the offset position or if the position is outside of the board, 
            //if is not a valid grid position then it finds a valid position to place the unit 
            if(LevelGrid.Instance.HasAnyUnitAtGridNode(offsetPosition) || !LevelGrid.Instance.CheckPositionValid(offsetPosition))
            {
                offsetPosition=LevelGrid.Instance.FindValidPosition(offsetPosition);
            } 
            // adds the position to the spawn point list and updates lastSpawnPointInList to find a new position
            playerUnitSpawnPointList.Add(offsetPosition);
            lastSpawnPointInList=offsetPosition;

        }
    }

    public void SwitchTurn()
    {
        TurnSystem.Instance.NextTurn();
        SetCurrentArmy();
    }

    public void SetCurrentArmy()
    {
        if(TurnSystem.Instance.IsPlayerTurn())
        {
            currentArmyList=playerUnitList;
        }
        else
        {
            currentArmyList=enemyUnitList;
        }
    }

    public List<Unit> GetEnemyUnitList()
    {
        return enemyUnitList;
    }





}
