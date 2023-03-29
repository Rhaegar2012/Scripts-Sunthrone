using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapGridNode 
{
    private int xPosition;
    private int yPosition;
    private Vector2 gridPosition;
    public Vector2 GridPosition {get{return gridPosition;}}
    private TilemapGridType nodeType;
    public  TilemapGridType NodeType{get{return nodeType;}}
    private List<TilemapGridNode> nodeNeighbourList=new List<TilemapGridNode>();


    public TilemapGridNode(Vector2 gridPosition,TilemapGridType nodeType)
    {
        this.gridPosition=gridPosition;
        this.nodeType=nodeType;
        xPosition=(int)this.gridPosition.x;
        yPosition=(int)this.gridPosition.y;

    }

    public List<TilemapGridNode> GetNodeNeighbourList()
    {
        return nodeNeighbourList;
    }

    public void AddNeighbourToList(TilemapGridNode neighbour)
    {
        nodeNeighbourList.Add(neighbour);
    }


}
