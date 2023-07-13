using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : SingletonMonobehaviour<Pathfinding>
{

    //Fields
    private List<TilemapGridNode> openList;
    private List<TilemapGridNode> closedList;
    private int width;
    private int height;
    private int xOrigin;
    private int yOrigin;
    private const int BASE_MOVEMENT_COST=10;
    private int pathLength;

    protected override void Awake()
    {
        base.Awake();    
    }
    void Start()
    {
        this.width=LevelGrid.Instance.GetTilemapWidth();
        this.height=LevelGrid.Instance.GetTilemapHeight();
        this.xOrigin=LevelGrid.Instance.GetTilemapOriginX();
        this.yOrigin=LevelGrid.Instance.GetTilemapOriginY();
    }
    public List<TilemapGridNode> FindPath(Unit selectedUnit, TilemapGridNode endNode)
    {
        int movementRange= selectedUnit.GetMovementRange();
        Vector2 startPosition=selectedUnit.GetUnitPosition();
        Vector2 endPosition= endNode.GetGridPosition();
        TilemapGridNode startNode=LevelGrid.Instance.GetNodeAtPosition(startPosition);
        openList= new List<TilemapGridNode>();
        closedList=new List<TilemapGridNode>();
        openList.Add(startNode);
        for(int x=xOrigin; x<width-1;x++)
        {
            for(int y=yOrigin;y<height-1;y++)
            {
                Debug.Log(y);
                TilemapGridNode gridNode=LevelGrid.Instance.GetNodeAtPosition(new Vector2(x,y));
                gridNode.SetGCost(int.MaxValue);
                gridNode.SetHCost(0);
                gridNode.CalculateFCost();
                gridNode.ResetPreviousNode();
            }
        }
        startNode.SetGCost(0);
        startNode.SetHCost(CalculateDistance(startPosition,endPosition));
        startNode.CalculateFCost();
        while(openList.Count>0)
        {
            TilemapGridNode currentNode=GetLowestFCostNode(openList);
            if(currentNode==endNode)
            {
                pathLength=currentNode.CalculateFCost();
                return CalculatePath(endNode);
            }
            openList.Remove(currentNode);
            closedList.Add(currentNode);
            foreach(TilemapGridNode neighbor in GetNeighbors(currentNode.GetGridPosition()))
            {
                if(closedList.Contains(neighbor))
                {
                    continue;
                }
                if(!selectedUnit.GetWalkableNodeTypeList().Contains(neighbor.GetNodeType()))
                {
                    closedList.Add(neighbor);
                    continue;
                }
                int tentativeGCost=currentNode.GetGCost()+CalculateDistance(currentNode.GetGridPosition(),neighbor.GetGridPosition());
                if(tentativeGCost<neighbor.GetGCost())
                {
                    neighbor.SetPreviousNode(currentNode);
                    neighbor.SetGCost(tentativeGCost);
                    neighbor.SetHCost(CalculateDistance(neighbor.GetGridPosition(),endPosition));
                    neighbor.CalculateFCost();
                    if(!openList.Contains(neighbor))
                    {
                        openList.Add(neighbor);
                    }
                }
            }
        }
        //No Path found 
        pathLength=0;
        return null;
        
    }
    private int CalculateDistance(Vector2 startPosition,Vector2 endPosition)
    {
        int distance=(int)Vector2.Distance(startPosition,endPosition);
        return distance*BASE_MOVEMENT_COST;
    }
    private TilemapGridNode GetLowestFCostNode(List<TilemapGridNode> gridNodeList)
    {
        int minFCost=int.MaxValue;
        TilemapGridNode minFCostNode=null;
        foreach(TilemapGridNode node in gridNodeList)
        {
            int fCost=node.GetFCost();
            if(fCost<minFCost)
            {
                minFCost=fCost;
                minFCostNode=node;
            }

        }
        return minFCostNode;
    }
    private List<TilemapGridNode> GetNeighbors(Vector2 gridPosition)
    {
        List<TilemapGridNode> neighborList= new List<TilemapGridNode>();
        List<Vector2> neighborPositions= new List<Vector2> {new Vector2(1,0),
                                                            new Vector2(-1,0),
                                                            new Vector2(0,1),
                                                            new Vector2(0,-1)};
        foreach(Vector2 offsetPosition in neighborPositions)
        {
            Vector2 testPosition=gridPosition+offsetPosition;
            if(LevelGrid.Instance.CheckPositionValid(testPosition))
            {
                TilemapGridNode neighbor=LevelGrid.Instance.GetNodeAtPosition(testPosition);
                neighborList.Add(neighbor);
            }
        }
        return neighborList;

    }
    private List<TilemapGridNode> CalculatePath(TilemapGridNode node)
    {
        List<TilemapGridNode> pathList=new List<TilemapGridNode>();
        pathList.Add(node);
        TilemapGridNode currentNode=node;
        while(currentNode.GetPreviousNode()!=null)
        {
            pathList.Add(currentNode.GetPreviousNode());
            currentNode=currentNode.GetPreviousNode();
        }
        pathList.Reverse();
        return pathList;
    }

    public int CalculateTotalMovementCostInPath(List<TilemapGridNode> path)
    {
        int totalMovementCost=0;
        foreach(TilemapGridNode node in path)
        {
            totalMovementCost+=(int)node.NodeType;

        }
        return totalMovementCost;
    }

}
