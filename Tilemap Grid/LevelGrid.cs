using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : SingletonMonobehaviour<LevelGrid>
{
  [SerializeField] SO_TilemapGridData tilemapData;
  [SerializeField] private TilemapProperties tilemapProperties;
  private TilemapGrid levelGrid;
  protected override void Awake()
  {
    base.Awake();
    className="Level Grid";
    //Initialize Tilemap Node Property list on Awake to prevent null reference exception
    tilemapProperties.UpdateTilemapProperties();
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

  public float GetCellSize()
  {
     throw new NotImplementedException();
  }

  public void SetUnitAtGridNode()
  {
    throw new NotImplementedException();
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

  public void UnitHealthSystem_OnUnitDestroyed()
  {
    throw new NotImplementedException();
  }


}
