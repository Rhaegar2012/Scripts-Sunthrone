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
    private bool unitCompletedAction;
    private BaseAction[] actionList;
    private TilemapGridNode currentNode;
    private Vector2 gridPosition;
    private AttackAction attackAction;
    private CaptureAction captureAction;
    private List<Vector2> validMovementPositions= new List<Vector2>();
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
        Debug.Log(gridNode.GetGridPosition());
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


    public List<Vector2> GetValidMovementPositionList(Vector2 position,int movementRange)
    {
        Debug.Log("Recursive Call");
        Queue<Vector2> queue=new Queue<Vector2>();
        List<Vector2> visited=new List<Vector2>(); 
        queue.Enqueue(position);
        while (queue.Count>0 && movementRange>0)
        {
            Vector2 currentPosition= queue.Dequeue();
            TilemapGridNode currentNode= LevelGrid.Instance.GetNodeAtPosition(currentPosition);
            validMovementPositions.Add(currentPosition); 
            if(movementRange>0)
            {
                Debug.Log($"Movement Range {movementRange}");
                List<TilemapGridNode> currentNodeNeighbors=currentNode.GetNodeNeighbourList();
                foreach(TilemapGridNode neighbour in currentNodeNeighbors)
                {
                    Vector2 neighbourPosition=neighbour.GetGridPosition();
                    NodeType neighbourNodeType= neighbour.GetNodeType();
                    
                    if(!visited.Contains(neighbourPosition) && walkableTiles.Contains(neighbourNodeType))
                    {
                        Debug.Log($"Neighbour Position x {neighbourPosition.x}");
                        Debug.Log($"Neighbour Position y {neighbourPosition.y}");
                        queue.Enqueue(neighbourPosition);
                        visited.Add(neighbourPosition);
                        //Update movement range
                        int penalty= (int) neighbourNodeType;
                        movementRange=movementRange-penalty;
                        if(movementRange<0)
                        {
                            movementRange=0;
                            return validMovementPositions;
                        }
                        Debug.Log($"updatedMovementRange {movementRange}");
                        //Recursive call
                        //GetValidMovementPositionList(neighbourPosition,movementRange);
                    
                    }

                }

            }
        }
        return validMovementPositions; 


       
    }

    public List<Vector2> GetValidMovementPositionList()
    {
        gridPosition=new Vector2(transform.position.x,transform.position.y);
        return GetValidMovementPositionList(gridPosition,baseMovementRange);
    }


    public List<Vector2> GetValidAttackPositionList()
    {
       
        attackAction=GetComponent<AttackAction>();
        return attackAction.GetValidGridPositionList();
    }

    public List<Vector2> GetValidCapturePositionList()
    {
        captureAction=GetComponent<CaptureAction>();
        return captureAction.GetValidGridPositionList();
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

    public void Damage(float damageAmount)
    {
        throw new NotImplementedException();
    }


    public List<NodeType> GetWalkableNodeTypeList()
    {
        throw new NotImplementedException();
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
       throw new NotImplementedException();
    }

    public float GetAttackRating()
    {
        throw new NotImplementedException();
    }

    public int GetHealth()
    {
        throw new NotImplementedException();
    }




    
}
    
