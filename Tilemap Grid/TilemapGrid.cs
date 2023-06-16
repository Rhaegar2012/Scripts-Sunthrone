using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapGrid
{
    private int tilemapWidth;
    public  int TilemapWidth{get{return tilemapWidth;}}
    private int tilemapHeight;
    public  int TilemapHeight{get{return tilemapHeight;}}
    private int tilemapOriginX;
    public int  TilemapOriginX{get{return tilemapOriginX;}}
    private int tilemapOriginY;
    public int  TilemapOriginY{get{return tilemapOriginY;}}
    private Dictionary<Vector2, TilemapGridNode> tilemapGridNodes;
    private List<NodeProperty> nodePropertyList;

    public TilemapGrid(SO_TilemapGridData gridData)
    {
        tilemapWidth=gridData.gridWidth;
        tilemapHeight=gridData.gridHeight;
        tilemapOriginX=gridData.originX;
        tilemapOriginY=gridData.originY;
        nodePropertyList=gridData.nodeProperties;
        tilemapGridNodes= new Dictionary<Vector2,TilemapGridNode>();
        InitialiseTilemapNodes(nodePropertyList);
        CreateNodeNeighbors();
    }

   

    private void InitialiseTilemapNodes(List<NodeProperty> nodePropertyList)
    {
        foreach(NodeProperty  nodeProperty in nodePropertyList)
        {
            TilemapGridNode newNode= new TilemapGridNode(nodeProperty.NodePosition,nodeProperty.NodeType);
            Debug.Log($"New node {newNode}");
            tilemapGridNodes.Add(nodeProperty.NodePosition,newNode);
        }
                
    }

    public TilemapGridNode GetNodeAtWorldPosition(Vector2 position)
    {
        return tilemapGridNodes[position];
    }

    public Dictionary<Vector2,TilemapGridNode> GetNodeDictionary()
    {
        return tilemapGridNodes;
    }

    

    public bool IsPositionValid(Vector2 position)
    {
        int x= (int)position.x;
        int y= (int)position.y;
        return (x>=tilemapOriginX && x<tilemapOriginX+tilemapWidth && y>=tilemapOriginY&&y<tilemapOriginY+tilemapHeight);
    }

    private void CreateNodeNeighbors()
    {
        Vector2[] neighborDirections={new Vector2(1,0),new Vector2(-1,0),
                                      new Vector2(0,1),new Vector2(0,-1)};
        for(int x=tilemapOriginX;x<=tilemapWidth+tilemapOriginX-1;x++)
        {
            for(int y=tilemapOriginY;y<tilemapHeight+tilemapOriginY-1;y++)
            {
                Vector2 currentPosition=new Vector2(x,y);
                TilemapGridNode currentNode=GetNodeAtWorldPosition(currentPosition);
                foreach(Vector2 direction in neighborDirections)
                {
                    Vector2 offsetPosition=currentPosition+direction;
                    if(IsPositionValid(offsetPosition))
                    {   
                        TilemapGridNode neighbourNode= GetNodeAtWorldPosition(offsetPosition);
                        currentNode.AddNeighbourToList(neighbourNode);
                    }

                }
            

            }
        }
       
    }


    



}
