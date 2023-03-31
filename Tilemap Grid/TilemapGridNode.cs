using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapGridNode 
{
    private int xPosition;
    private int yPosition;
    private Vector2 nodePosition;
    public Vector2 NodePosition {get{return nodePosition;}}
    private TilemapGridType nodeType;
    public  TilemapGridType NodeType{get{return nodeType;}}
    private List<TilemapGridNode> nodeNeighbourList=new List<TilemapGridNode>();


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


}
