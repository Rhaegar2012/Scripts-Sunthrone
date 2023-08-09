using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[ExecuteAlways]
[System.Serializable]
public class TilemapProperties : MonoBehaviour
{
   [SerializeField] private Tilemap tilemap;
   [SerializeField] private NodeType tilemapType;
   [SerializeField] private SO_TilemapGridData tilemapGridData;
   private void OnEnable()
   {
        if(tilemapGridData.nodeProperties!=null)
        {
            return;
        }
        //tilemapGridData.nodeProperties=new List<NodeProperty>();
        
   }
   //Populates tilemap properties dictionary in designated Scriptable object
   private void OnDisable()
   {
        
        
        if(!Application.IsPlaying(gameObject))
        {
            
            UpdateTilemapProperties(0);
            
        }

   }

   public void UpdateTilemapProperties(int numberOfTilemaps)
   {

       //Verifies if the nodeProperties list has already been populated for single layer tilemaps
       if(tilemapGridData.nodeProperties.Count>0 && numberOfTilemaps==1)
       {
            return;
       }
       //Verifies if the nodePropertiesList has already been populated for multiple layer tilemaps
       if(numberOfTilemaps>1)
       {
         int tilemapSize= tilemapGridData.gridWidth*tilemapGridData.gridHeight;
         if(tilemapGridData.nodeProperties.Count>= tilemapSize)
         {
            return;
         }
       }
       Vector3 startCellPosition=tilemap.cellBounds.min;
       Vector3 endCellPosition=tilemap.cellBounds.max;
       for(int x=(int)startCellPosition.x;x<(int)endCellPosition.x;x++)
       {
            for(int y=(int)startCellPosition.y;y<(int)endCellPosition.y;y++)
            {
                TileBase tile = tilemap.GetTile(new Vector3Int(x,y,0));
                if(tile!=null)
                {
        
                    NodeProperty nodeProperty =new NodeProperty(new Vector2(x,y),tilemapType);
                    tilemapGridData.nodeProperties.Add(nodeProperty);
                    
                }
            }
       }

   }
}
