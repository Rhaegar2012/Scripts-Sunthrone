using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : SingletonMonobehaviour<LevelGrid>
{
  [SerializeField] SO_TilemapGridData tilemapData;
  [SerializeField] private List<TilemapProperties> tilemapProperties;
  private TilemapGrid levelGrid;
  public List<TilemapProperties> TilemapProperties {get{return tilemapProperties;}} 
  protected override void Awake()
  {
    base.Awake();
    className="Level Grid";
    //Initialize Tilemap Node Property list on Awake to prevent null reference exception
    foreach(TilemapProperties tilemap in tilemapProperties)
    {
      tilemap.UpdateTilemapProperties(tilemapProperties.Count);
    }
    levelGrid= new TilemapGrid(tilemapData);
  
  }

  public int GetTilemapHeight()
  {
    return levelGrid.TilemapHeight;
  }

  public int GetTilemapWidth()
  {
    return levelGrid.TilemapWidth;
  }

  public float GetTilemapCellSize()
  {
    return (float)levelGrid.CellSize;
  }

  public int GetTilemapSize()
  {
    return levelGrid.TilemapHeight*levelGrid.TilemapWidth;
  }
  public Vector2 GetTilemapOrigin()
  {
    return new Vector2(levelGrid.TilemapOriginX,levelGrid.TilemapOriginY);
  }

  public Dictionary<Vector2, TilemapGridNode> GetNodeDictionary()
  {
    return levelGrid.GetNodeDictionary();
  }

  public TilemapGridNode GetNodeAtPosition(Vector2 position)
  {
    return levelGrid.GetNodeAtWorldPosition(position);
  }

  public bool CheckPositionValid(Vector2 position)
  {
    return levelGrid.IsPositionValid(position);
  }

  public List<TilemapGridNode> GetNodeNeighborsAtPosition(Vector2 position)
  {
    if(levelGrid.IsPositionValid(position))
    {
      TilemapGridNode node=levelGrid.GetNodeAtWorldPosition(position);
      return node.GetNodeNeighbourList();
    }
    return null;
  }

  public Vector2 GetGridPositionFromWorldPosition(Vector2 worldPosition)
  {
    Vector2 gridPosition= new Vector2(worldPosition.x-GetTilemapCellSize()/2,
                                      worldPosition.y-GetTilemapCellSize()/2);
    return gridPosition;
  }

  public float GetCellSize()
  {
     throw new NotImplementedException();
  }

  public void SetUnitAtGridNode(Vector2 position,Unit unit)
  {
     if(levelGrid.IsPositionValid(position))
     {
        TilemapGridNode node= levelGrid.GetNodeAtWorldPosition(position);
        node.Unit=unit;
     }
  }

  public void SetTargetAtGridNode()
  {
    throw new NotImplementedException();
  }

  public Unit GetUnitAtGridNode(Vector2 gridPosition)
  {
    throw new NotImplementedException();
  }
  public Target GetTargetAtGridNode(Vector2 gridPosition)
  {
    throw new NotImplementedException();
  }

  public bool HasAnyUnitAtGridNode(Vector2 gridPosition)
  {
    throw new NotImplementedException();
  }

  public bool HasAnyTargetAtGridNode(Vector2 gridPosition)
  {
    throw new NotImplementedException();
  }

  public void RemoveUnitAtGridNode()
  {
    throw new NotImplementedException();
  }

  public void RemoveTargetAtGridNode()
  {
    throw new NotImplementedException();
  }

  public void MoveUnitGridPosition()
  {
    throw new NotImplementedException();
  }

  public NodeType GetNodeType()
  {
    throw new NotImplementedException();
  }

  public Vector2 FindValidPosition(Vector2 originPosition)
  {
    Vector2[] searchDirections={new Vector2(1f,1f), new Vector2(1f,0f),
                                new Vector2(1f,-1f), new Vector2(0f,-1f),
                                new Vector2(-1f,-1f),new Vector2(-1f,0f),
                                new Vector2(-1f,1f), new Vector2(0f,1f)};
    foreach(Vector2 direction in searchDirections)
    {
        Vector2 offsetPosition=originPosition+direction;
        if(!CheckPositionValid(offsetPosition))
        {
           continue;
        }
        if(HasAnyUnitAtGridNode(offsetPosition))
        {
           continue;
        }
        return offsetPosition;
    }
    return new Vector2(0f,0f);
  }

  public void UnitHealthSystem_OnUnitDestroyed()
  {
    throw new NotImplementedException();
  }


}
