using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapGridNode 
{
    private int xPosition;
    private int yPosition;
    private Vector2 nodePosition;
    private TilemapGridType nodeType;
    private List<TilemapGridNode> nodeNeighbourList=new List<TilemapGridNode>();
    private Unit unit;
    //Properties
    public Vector2 NodePosition {get{return nodePosition;}}
    public  TilemapGridType NodeType{get{return nodeType;}}
    public Unit Unit {get{return unit;}set{unit=value;}}



    public TilemapGridNode(Vector2 gridPosition,TilemapGridType nodeType)
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


}
