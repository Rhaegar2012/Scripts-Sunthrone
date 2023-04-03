using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : SingletonMonobehaviour<LevelGrid>
{
  [SerializeField] SO_TilemapGridData tilemapData;
  private TilemapGrid levelGrid;
  protected override void Awake()
  {
    base.Awake();
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





}
