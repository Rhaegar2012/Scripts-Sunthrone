using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NodeProperty 
{
   private Vector2 nodePosition;
   public Vector2 NodePosition{get{return nodePosition;}}
   private TilemapGridType nodeType;
   public TilemapGridType NodeType{get{return nodeType;}}
   public NodeProperty(Vector2 position, TilemapGridType type)
   {
        nodePosition=position;
        nodeType=type;
   }
}
