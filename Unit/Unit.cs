using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private string unitName;
    [SerializeField] private int healthPoints;
    [SerializeField] private int attackPower;
    [SerializeField] private int defense;
    [SerializeField] private int baseMovementRange;
    [SerializeField] private UnitLevel unitLevel;
    [SerializeField] private Sprite unitSprite;
    [SerializeField] private List<NodeType> walkableTiles;
    [SerializeField] private int unitCreditCost;
    [SerializeField] private int unitSupplyCost;
    [SerializeField] private int unitUpgradeCost;
    [SerializeField] private bool isEnemy;
    private int unitExperience;
    private int damageAmount;
    private bool unitCompletedAction;
    private BaseAction[] actionList;
    private TilemapGridNode currentNode;
    private Vector2 gridPosition;
    private AttackAction attackAction;
    private CaptureAction captureAction;
    private List<Vector2> validMovementPositions= new List<Vector2>();
    private List<Vector2> validAttackPositions= new List<Vector2>();
    private List<Vector2> validCapturePositions= new List<Vector2>();
    //Properties
    public string UnitName {get{return unitName;}set{unitName=value;}}
    public Vector2 GridPosition {get{return gridPosition;} set{gridPosition=value;}}
    public TilemapGridNode CurrentNode {get{return currentNode;} set{currentNode=value;}}
    public int HealthPoints {get{return healthPoints;}set{healthPoints=value;}}
    public int AttackPower  {get{return attackPower;}set{attackPower=value;}}
    public int Defense {get{return defense;}set{defense=value;}}
    public int UnitCreditCost {get{return unitCreditCost;}set{unitCreditCost=value;}}
    public int UnitSupplyCost {get{return unitSupplyCost;}set{unitSupplyCost=value;}}
    public int BaseMovementRange{get{return baseMovementRange;} set{baseMovementRange=value;}}
    public UnitLevel UnitLevel {get{return unitLevel;} set{unitLevel=value;}}
    public Sprite UnitSprite {get{return unitSprite;} set{unitSprite=value;}}
    public int UnitUpgradeCost {get{return unitUpgradeCost;} set{unitUpgradeCost=value;}}
    public int UnitExperience {get{return unitExperience;} set{unitExperience=value;}}
    public int DamageAmount {get{return damageAmount;} set{damageAmount=value;}}
    public List<Vector2> ValidMovementPositions {get{return validMovementPositions;}}
    void Awake()
    {
          
    }
    void Start()
    {
        actionList=GetComponents<BaseAction>();
    }
    public bool IsEnemy()
    {
        return isEnemy;
    }

    public TilemapGridNode GetUnidNode()
    {
        return currentNode;
    }
    
    public void SetUnitNode(TilemapGridNode gridNode)
    {
        currentNode=gridNode;
    }

    public Vector2 GetUnitPosition()
    {
        return gridPosition;
    }

    public UnitType GetUnitType()
    {
        throw new NotImplementedException();
    }

    public int GetMovementRange()
    {
        return baseMovementRange;
    }


    public List<Vector2> GetValidMovementPositionList(Vector2 position)
    {
        
        for(int x=-baseMovementRange;x<baseMovementRange;x++)
        {
            for(int y=-baseMovementRange;y<baseMovementRange;y++)
            {
                Vector2 testPosition= new Vector2(gridPosition.x+x,gridPosition.y+y);
                if(!LevelGrid.Instance.CheckPositionValid(testPosition))
                {
                    continue;
                }
                if(LevelGrid.Instance.HasAnyUnitAtGridNode(testPosition))
                {
                    continue;
                }
                TilemapGridNode endNode= LevelGrid.Instance.GetNodeAtPosition(testPosition);
                List<TilemapGridNode> pathToNode=new List<TilemapGridNode>();
                pathToNode=Pathfinding.Instance.FindPath(this,endNode);
                int totalMovementCost=Pathfinding.Instance.CalculateTotalMovementCostInPath(pathToNode);
                if(totalMovementCost>baseMovementRange)
                {
                    continue;
                }
                validMovementPositions.Add(testPosition);
                
            }
        }
        return validMovementPositions;


       
    }

    public List<Vector2> GetValidMovementPositionList()
    {
        gridPosition=new Vector2(transform.position.x,transform.position.y);
        return GetValidMovementPositionList(gridPosition);
    }

 
    public List<Vector2> GetValidAttackPositionList()
    {
       
        attackAction=GetComponent<AttackAction>();
        validAttackPositions=attackAction.GetValidGridPositionList();
        return validAttackPositions;
    }

    public List<Vector2> GetValidCapturePositionList()
    {
        captureAction=GetComponent<CaptureAction>();
        validCapturePositions=captureAction.GetValidGridPositionList();
        return validCapturePositions;
    }

    
    public BaseAction GetAction(string actionName)
    {
        BaseAction selectedAction=Array.Find(actionList,action=>action.GetActionName()==actionName);
        return selectedAction;
    }

    public BaseAction[] GetActionArray()
    {
        throw new NotImplementedException();
    }

    public void SetWalkableNodeTypes()
    {
        throw new NotImplementedException();
    }

    public void Damage(int damageAmount)
    {
        healthPoints-= damageAmount;
        if(healthPoints<0)
        {
            healthPoints=0;
        }
    }


    public List<NodeType> GetWalkableNodeTypeList()
    {
        return walkableTiles;
    }

    public bool UnitCompletedAction()
    {
        return unitCompletedAction;
    }

    public void SetCompletedAction(bool completedAction)
    {
       unitCompletedAction=completedAction;
    }

    public void TurnSystem_OnTurnChanged()
    {
       throw new NotImplementedException();
    }

    public float GetDefenseRating()
    {
       return defense;
    }

    public float GetAttackRating()
    {
        return attackPower;
    }

    public int GetHealth()
    {
        return healthPoints;
    }




    
}
    
