using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneItem : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private bool isActiveInScene;
    [SerializeField] private SceneItemType itemType;
    public string ItemName {get{return itemName;} set{itemName=value;}}
    public bool IsActiveInScene {get{return isActiveInScene;} set{isActiveInScene=value;}}


    public void SetActiveInScene(bool isActive)
    {
        IsActiveInScene=isActive;
        gameObject.SetActive(isActive);
    }

    public void SetActiveInScene()
    {
        SetActiveInScene(isActiveInScene);
    }
}
