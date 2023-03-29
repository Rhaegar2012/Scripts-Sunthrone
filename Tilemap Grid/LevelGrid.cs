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





}
