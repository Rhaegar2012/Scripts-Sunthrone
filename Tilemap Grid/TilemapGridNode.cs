using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapGridNode 
{
    private int xPosition;
    private int yPosition;
    private int gCost;
    private int hCost;
    private int fCost;
    private TilemapGridNode previousNode;
    private Vector2 nodePosition;
    private NodeType nodeType;
    private List<TilemapGridNode> nodeNeighbourList=new List<TilemapGridNode>();
    private Unit unit;
    
    //Properties
    public Vector2 NodePosition {get{return nodePosition;}}
    public NodeType NodeType{get{return nodeType;}}
    public Unit Unit {get{return unit;}set{unit=value;}}



    public TilemapGridNode(Vector2 gridPosition,NodeType nodeType)
    {
        this.nodePosition=gridPosition;
        this.nodeType=nodeType;
        xPosition=(int)nodePosition.x;
        yPosition=(int)nodePosition.y;

    }

    public List<TilemapGridNode> GetNodeNeighbourList()
    {
        return nodeNeighbourList;
    }

    public void AddNeighbourToList(TilemapGridNode neighbour)
    {
        nodeNeighbourList.Add(neighbour);
    }

    public bool HasAnyUnit()
    {
        if(unit!=null)
        {
            return true;
        }
        return false;
    }

    public Unit GetUnit()
    {
        return Unit;
    }

    public Vector2 GetGridPosition()
    {
        return nodePosition;
    }

    public NodeType GetNodeType()
    {
        return nodeType;
    }

    public int GetGCost()
    {
        return gCost;
    }

    public int GetHCost()
    {
        return hCost;
    }

    public int GetFCost()
    {
        return fCost;
    }

    public void SetGCost(int gCost)
    {
        this.gCost=gCost;
    }

    public void SetHCost(int hCost)
    {
        this.hCost=hCost;
    } 

    public int CalculateFCost()
    {
        return fCost=gCost+hCost;
    }

    public TilemapGridNode GetPreviousNode()
    {
        return previousNode;
    }

    public void SetPreviousNode(TilemapGridNode previousNode)
    {
        this.previousNode=previousNode;
    }

    public void ResetPreviousNode()
    {
        previousNode=null;
    }

    public bool IsAttackNode()
    {
        throw new NotImplementedException();
    }

    public void SetAttackNode(bool isAttackNode)
    {
        throw new NotImplementedException();
    }


}
