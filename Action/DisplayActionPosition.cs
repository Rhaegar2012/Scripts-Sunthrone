using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayActionPosition : MonoBehaviour
{
    [SerializeField] private GameObject validMovementPositionTilePrefab;
    [SerializeField] private GameObject validAttackPositionTilePrefab;
    [SerializeField] private GameObject validCapturePositionTilePrefab;
    List<GameObject> activePositionTilesList;
    // Start is called before the first frame update
    void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged+=DisplayValidActionPositions;
        activePositionTilesList=new List<GameObject>();
    }

    public void DisplayValidActionPositions(object sender , EventArgs empty)
    {
        Debug.Log("Called display action");
        Unit selectedUnit= UnitActionSystem.Instance.GetSelectedUnit();
        List<Vector2> validMovementPositionList=selectedUnit.GetValidMovementPositionList();
        Debug.Log($"Movement list {validMovementPositionList.Count}");
        List<Vector2> validAttackPositionList= selectedUnit.GetValidAttackPositionList();
        Debug.Log($"Movement list {validAttackPositionList.Count}");
        //TODO Hydrate capture position display when the target class is implemented
        //List<Vector2> validCapturePositionList= selectedUnit.GetValidCapturePositionList();
        //Debug.Log($"Movement list {validCapturePositionList.Count}");
        //Clears active position tiles when unit is changed
        if(activePositionTilesList.Count>0)
        {
            foreach(GameObject tile in activePositionTilesList)
            {
                Destroy(tile.gameObject);
            }
            activePositionTilesList.Clear();
        }
        foreach(Vector2 position in validMovementPositionList)
        {
            GameObject movementTile=Instantiate(validMovementPositionTilePrefab,new Vector3(position.x,position.y,0f), Quaternion.identity);
            activePositionTilesList.Add(movementTile);
        }

        foreach(Vector2 position in validAttackPositionList)
        {
            GameObject attackTile=Instantiate(validAttackPositionTilePrefab,new Vector3(position.x,position.y,0f), Quaternion.identity);
            activePositionTilesList.Add(attackTile);
        }
        //TODO Hydreate capture position display when the target class is implemented 
        /*foreach(Vector2 position in validCapturePositionList)
        {
            GameObject captureTile=Instantiate(validCapturePositionTilePrefab,new Vector3(position.x,position.y,0f), Quaternion.identity);
            activePositionTilesList.Add(captureTile);
        }*/




    }


}
