using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayActionPosition : MonoBehaviour
{
    [SerializeField] private GameObject validMovementPositionTile;
    [SerializeField] private GameObject validAttackPositionTile;
    [SerializeField] private GameObject validCapturePositionTile;
    List<GameObject> activePositionTilesList;
    // Start is called before the first frame update
    void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged+=DisplayValidActionPositions;
        activePositionTilesList=new List<GameObject>();
    }

    private void DisplayValidActionPositions()
    {
        Unit selectedUnit= UnitActionSystem.Instance.GetSelectedUnit();
        List<Vector2> validActionPositionList= new List<Vector2>();
        //Clears active position tiles when unit is changed
        if(activePositionTilesList.Count>0)
        {
            foreach(GameObject tile in activePositionTilesList)
            {
                Destroy(tile.gameObject);
            }
            activePositionTilesList.Clear();
        }
        validActionPositionList=selectedUnit.GetValidMovementPositionList();


    }


}
