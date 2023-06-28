using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NodeProperty 
{
   private Vector2 nodePosition;
   public Vector2 NodePosition{get{return nodePosition;}}
   private NodeType nodeType;
   public NodeType NodeType{get{return nodeType;}}
   public NodeProperty(Vector2 position, NodeType type)
   {
        nodePosition=position;
        nodeType=type;
   }
}
