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
    private TilemapGridNode [,] tilemapGridNodeArray;
    private Dictionary<Vector2, TilemapGridType> tilemapNodeDictionary;

    public TilemapGrid(SO_TilemapGridData gridData)
    {
        tilemapWidth=gridData.gridWidth;
        tilemapHeight=gridData.gridHeight;
        tilemapOriginX=gridData.originX;
        tilemapOriginY=gridData.originY;
        tilemapNodeDictionary=gridData.gridNodeTypes;
        tilemapGridNodeArray= new TilemapGridNode[tilemapWidth,tilemapHeight];
        InitialiseTilemapNodes(tilemapNodeDictionary);
        CreateNodeNeighbors();
    }

    private void InitialiseTilemapNodes(Dictionary<Vector2,TilemapGridType> nodeDictionary)
    {
        foreach(KeyValuePair<Vector2,TilemapGridType> node in nodeDictionary)
        {
            TilemapGridNode newNode= new TilemapGridNode(node.Key,node.Value);
            tilemapGridNodeArray[(int)node.Key.x,(int)node.Key.y]=newNode;
        }
                
    }

    public TilemapGridNode GetNodeAtGridPosition(Vector2 position)
    {
        return tilemapGridNodeArray[(int)position.x,(int)position.y];
    }

    public TilemapGridType GetNodeTypeAtGridPosition(Vector2 position)
    {
        return tilemapGridNodeArray[(int)position.x,(int)position.y].NodeType;
    }

    public bool IsPositionValid(Vector2 position)
    {
        int x= (int)position.x;
        int y= (int)position.y;
        return (x>=tilemapOriginX && x<=tilemapOriginX+tilemapWidth && y>=tilemapOriginY&&y<=tilemapOriginY+tilemapHeight);
    }

    private void CreateNodeNeighbors()
    {
        Vector2[] neighborDirections={new Vector2(1,0),new Vector2(-1,0),
                                      new Vector2(0,1),new Vector2(0,-1)};
        for(int x=tilemapOriginX;x<=tilemapWidth;x++)
        {
            for(int y=tilemapOriginY;y<=tilemapHeight;y++)
            {
                Debug.Log($"{x}{y}");
                TilemapGridNode currentNode=GetNodeAtGridPosition(new Vector2(x,y));
                foreach(Vector2 direction in neighborDirections)
                {
                    Vector2 testPosition=new Vector2(x,y)+direction;
                    if(IsPositionValid(testPosition))
                    {
                        TilemapGridNode neighborNode=GetNodeAtGridPosition(testPosition);
                        currentNode.AddNeighbourToList(neighborNode);
                    }
                }

            }
        }
    }


    



}
