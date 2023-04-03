using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid_Testing : MonoBehaviour
{

    [SerializeField] SO_TilemapGridData so_tilemapGridData;
    void Start()
    {
        LevelGridDescriptors();
        NodeNeighbours();
        
    }

    private void LevelGridDescriptors()
    {
        Debug.Log($"Level Grid Height {LevelGrid.Instance.GetTilemapHeight().ToString()}");
        Debug.Log($"Level Grid Width {LevelGrid.Instance.GetTilemapWidth().ToString()}");
        Debug.Log($"Level Grid Tilemap Origin {LevelGrid.Instance.GetTilemapOrigin().ToString()}");
        Debug.Log($"Level Grid Number of Nodes {LevelGrid.Instance.GetNodeDictionary().Count}");
    }

    private void NodeNeighbours()
    {
        List<NodeProperty> nodePropertyList=so_tilemapGridData.nodeProperties;
        foreach(NodeProperty node in nodePropertyList)
        {
            TilemapGridNode currentNode= LevelGrid.Instance.GetNodeAtPosition(node.NodePosition);
            Debug.Log($"Neighbour Count for Node {currentNode.NodePosition} is {currentNode.GetNodeNeighbourList().Count}");
        }
    }

    
}
