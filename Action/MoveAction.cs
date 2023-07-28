using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction
{
    //Events
    public static event EventHandler OnAnyUnitMoved;
    //Fields
    [SerializeField] private float moveSpeed;
    private float stoppingDistance=0.1f;
    private Vector2 currentGridPosition;
    private Vector2 targetPosition;
    private int currentIndex;
    private List<TilemapGridNode> pathList;
    private float distanceToTargetNode;
    // Start is called before the first frame update
    void Start()
    {
        currentGridPosition=unit.GetUnitPosition();
        pathList=new List<TilemapGridNode>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            return;
        }
        targetPosition=pathList[currentIndex].GetGridPosition();
        float distanceToTarget= Vector2.Distance(currentGridPosition,targetPosition);
        Vector2 moveDirection=(targetPosition-currentGridPosition).normalized;
        if(distanceToTarget>stoppingDistance)
        {
            transform.position+=new Vector3(moveDirection.x,moveDirection.y,0f)*moveSpeed*Time.deltaTime;
            currentGridPosition=new Vector2(transform.position.x,transform.position.y);

        }
        else
        {
            transform.position=new Vector2(Mathf.Round(currentGridPosition.x),Mathf.Round(currentGridPosition.y));
            currentIndex++;
            
        }
        if(currentIndex>=pathList.Count)
        {
            Vector2 finalGridPosition=pathList[pathList.Count-1].GetGridPosition();
            //Update unit and Level Grid nodes and positions
            TilemapGridNode finalNode=LevelGrid.Instance.GetNodeAtPosition(finalGridPosition);
            LevelGrid.Instance.RemoveUnitAtGridNode(unit.GridPosition);
            unit.GridPosition=finalGridPosition;
            unit.SetUnitNode(finalNode);
            LevelGrid.Instance.SetUnitAtGridNode(finalGridPosition,unit);
            //Complete action
            unit.SetCompletedAction(true);
            ActionComplete();
        }
        
    }
    public override string GetActionName()
    {
        return "Move";
    }
    public override List<Vector2> GetValidGridPositionList()
    {
        List<Vector2> validMovementPositionList=unit.GetValidMovementPositionList();
        return validMovementPositionList;
    }
    public override void TakeAction(Vector2 gridPosition, Action onActionComplete)
    {
        
        currentIndex=0;
        targetPosition=gridPosition;
        List<Vector2> validGridPositions= unit.ValidMovementPositions;
        //If an attack position is outside of movement range allows enemy to move to the edge of 
        //the movement range to get closer for attack
        //(Enemy AI)
        if(!validGridPositions.Contains(targetPosition))
        {
            targetPosition=validGridPositions.Find(position=>Vector2.Distance(position,gridPosition)>=unit.GetMovementRange());
        }

        TilemapGridNode targetNode=LevelGrid.Instance.GetNodeAtPosition(targetPosition);
        pathList= Pathfinding.Instance.FindPath(unit,targetNode);
        OnAnyUnitMoved?.Invoke(this,EventArgs.Empty);
        ActionStart(onActionComplete);
        
    }
    public override EnemyAIAction GetEnemyAIAction(Vector2 gridPosition)
    {
        //Checks if there is an enemy in this position to be attacked
        AttackAction attackAction=unit.GetAction("Attack") as AttackAction;
        int enemyCount=attackAction.GetTargetCountAtPosition(gridPosition);
        if(enemyCount==0)
        {
            distanceToTargetNode=Vector2.Distance(unit.GetUnitPosition(),gridPosition);
            return new EnemyAIAction
            {
                actionValue=(int)distanceToTargetNode*5,
                gridPosition=gridPosition
            };
        }
        return new EnemyAIAction
        {
            actionValue=enemyCount*10,
            gridPosition=gridPosition
        };
    }
}
