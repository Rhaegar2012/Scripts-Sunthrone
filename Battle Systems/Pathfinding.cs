using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    //Singleton
    public static Pathfinding Instance {get; private set;}
    //Fields
    private List<TilemapGridNode> openList;
    private List<TilemapGridNode> closedList;
    private int width;
    private int height;
    private const int BASE_MOVEMENT_COST=10;
    private int pathLength;

    void Awake()
    {
        if(Instance!=null)
        {
            Debug.LogWarning("Pathfinding singleton instance already exists");
            Destroy(gameObject);
            return;
        }
        Instance=this;
    }
    void Start()
    {
        this.width=LevelGrid.Instance.GetTilemapWidth();
        this.height=LevelGrid.Instance.GetTilemapHeight();
    }
    public List<TilemapGridNode> FindPath(Unit selectedUnit,List<Vector2> validGridPositionList, TilemapGridNode endNode)
    {
        int movementRange= selectedUnit.GetMovementRange();
        Vector2 startPosition=selectedUnit.GetUnitPosition();
        Vector2 endPosition= endNode.GetGridPosition();
        TilemapGridNode startNode=LevelGrid.Instance.GetNodeAtPosition(startPosition);
        if(!validGridPositionList.Contains(endPosition))
        {
    
            return null; 
        }
        openList= new List<TilemapGridNode>();
        closedList=new List<TilemapGridNode>();
        openList.Add(startNode);
        for(int x=0; x<width;x++)
        {
            for(int y=0;y<height;y++)
            {
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

}
