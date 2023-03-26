using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapProperties : MonoBehaviour
{
   [SerializeField] private Tilemap tilemap;
   [SerializeField] private TilemapGridType tilemapType;
   [SerializeField] private SO_TilemapGridData tilemapGridData
   //Populates tilemap properties dictionary in designated Scriptable object
   private void OnEnable()
   {

        if(!Application.isRunning)
        {
            //TODO populate tilemap dictionary properties 
        }

   }
}
