using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[ExecuteAlways]
[System.Serializable]
public class TilemapProperties : MonoBehaviour
{
#if UNITY_EDITOR
   [SerializeField] private Tilemap tilemap;
   [SerializeField] private TilemapGridType tilemapType;
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
            
            UpdateTilemapProperties();
            
        }

   }

   public void UpdateTilemapProperties()
   {
       //Debug.Log("Call to Update Tilemap Properties Method");
       //Clear list
       if(tilemapGridData.nodeProperties!=null)
       {
            tilemapGridData.nodeProperties.Clear();
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
#endif
}
