using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapGrid
{
    private int tilemapWidth;
    private int tilemapHeight;
    private int tilemapOriginX;
    private int tilemapOriginY;
    private TilemapGridNode [,] tilemapGridNodeArray;

    public TilemapGrid(SO_TilemapGridData gridData)
    {
        tilemapWidth=gridData.gridWidth;
        tilemapHeight=gridData.gridHeight;
        tilemapOriginX=gridData.originX;
        tilemapOriginY=gridData.originY;
        InitialiseTilemapNodes();
    }

    private void InitialiseTilemapNodes()
    {
        for(int x=tilemapOriginX;x<tilemapWidth;x++)
        {
            for(int y=tilemapOriginY;y<tilemapHeight;y++)
            {
                TilemapGridNode newNode= new TilemapGridNode(new Vector2(x,y),TilemapGridType.Grassland);
            }
        }
    }


    



}
