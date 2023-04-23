using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEntrance : MonoBehaviour
{
    [SerializeField] private string buildingEntranceName;
    [SerializeField] private Vector3 entranceExitPosition;
    //Events 
    public static event EventHandler<Vector3> onEntranceTriggered;
    private void OnTriggerEnter2D(Collider2D other)
    {
        LevelManager.Instance.LoadScene(buildingEntranceName);
        onEntranceTriggered?.Invoke(this,entranceExitPosition);
    }
}
