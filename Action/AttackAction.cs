using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : BaseAction
{
    //Fields
    Unit targetUnit;
    private BaseAction moveAction;
    private int movementRange;
    private Vector2 attackPosition;
    List<Unit> enemiesInRange=new List<Unit>();



    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        moveAction=GetComponent<MoveAction>();
    }
    void Start()
    {
        movementRange=unit.GetMovementRange();  
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            return;
        }
        if(unit.GetUnitPosition()==attackPosition)
        {
            
            unit.SetCompletedAction(true);
            int damageAmount=CalculateDamage();
            targetUnit.DamageAmount=damageAmount;
            targetUnit.TakeDamage();
            ActionComplete();
        }
     

    }

    private int CalculateDamage()
    {
        float baseAttack=unit.GetAttackRating();
        float baseDefense=targetUnit.GetDefenseRating();
        int damageAmount=(int)(Mathf.Ceil(baseAttack-baseDefense));
        return damageAmount;

    }
    public override string GetActionName()
    {
        return "Attack";
    }
    public override List<Vector2> GetValidGridPositionList()
    {
        Vector2 gridPosition= unit.GetUnitPosition();
        return GetValidGridPositionList(gridPosition);
    }
    public  List<Vector2> GetValidGridPositionList(Vector2 unitGridPosition)
    {
        List<Vector2> validGridPositionList=new List<Vector2>();
        for(int x=-movementRange;x<movementRange;x++)
        {
            for(int y=-movementRange;y<movementRange;y++)
            {
                Vector2 offsetPosition= new Vector2(x,y);
                Vector2 testPosition= unitGridPosition+offsetPosition;
                if(!LevelGrid.Instance.CheckPositionValid(testPosition))
                {
                    continue;
                }
                if(!LevelGrid.Instance.HasAnyUnitAtGridNode(testPosition))
                {
                    continue;
                }
                Unit testUnit=LevelGrid.Instance.GetUnitAtGridNode(testPosition);
                if(testUnit.IsEnemy()==unit.IsEnemy())
                {
                    continue;
                }
                validGridPositionList.Add(testPosition);              
            }
        }
        return validGridPositionList;
    }
    public override EnemyAIAction GetEnemyAIAction(Vector2 gridPosition)
    {
        
        return new EnemyAIAction
        {
            gridPosition=gridPosition,
            actionValue=100
        };
     
    }
    public int GetTargetCountAtPosition(Vector2 gridPosition)
    {
        enemiesInRange.Clear();
        GetValidGridPositionList();
        return enemiesInRange.Count;
    }
    


    public override void TakeAction(Vector2 gridPosition, Action onActionComplete)
    {
        Unit testUnit=LevelGrid.Instance.GetUnitAtGridNode(gridPosition);
        if(testUnit.IsEnemy()!=unit.IsEnemy())
        {
            targetUnit=testUnit;
        }
        attackPosition=FindAttackPosition(gridPosition);
        moveAction.TakeAction(attackPosition,onActionComplete);
        ActionStart(onActionComplete);
    }

    private Vector2 FindAttackPosition(Vector2 attackNode)
    {
        List<Vector2> attackDirections= new List<Vector2>{new Vector2(1,0f),
                                                          new Vector2(-1,0f),
                                                          new Vector2(0f,1f),
                                                          new Vector2(0f,-1f)};
        
        float distance= float.MaxValue;
        Vector2 unitPosition=unit.GetUnitPosition();
        Vector2 attackPosition= new Vector2(0f,0f);
        foreach(Vector2 direction in attackDirections)
        {
            Vector2 testPosition= attackNode+direction;
            NodeType nodeType=LevelGrid.Instance.GetNodeType(testPosition);
            if(!LevelGrid.Instance.CheckPositionValid(testPosition))
            {
                continue;
            }
            if(LevelGrid.Instance.HasAnyUnitAtGridNode(testPosition))
            {
                continue;
            }
            if(!unit.ValidMovementPositions.Contains(testPosition))
            {
                continue;
            }
            float distanceToPosition=Vector2.Distance(testPosition,unitPosition);
            if(distanceToPosition<distance)
            {
                attackPosition=testPosition;
                distance=distanceToPosition;
            }

        }
        return attackPosition;

    }
 
}
