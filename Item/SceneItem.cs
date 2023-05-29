using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneItem : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private bool isActiveInScene;
    [SerializeField] private SceneItemType itemType;
    [SerializeField] private GameObject itemPrefab;
    private Transform parentTransform;
    public string ItemName {get{return itemName;} set{itemName=value;}}
    public bool IsActiveInScene {get{return isActiveInScene;} set{isActiveInScene=value;}}
    public Transform ParentTransform {get{return parentTransform;}set{parentTransform=value;}}
    public GameObject ItemPrefab{get{return itemPrefab;}}



    public void SetActiveInScene(bool isActive)
    {

        gameObject.SetActive(isActive);
        IsActiveInScene=isActive;
        
    }

    public void SetActiveInScene()
    {
        SetActiveInScene(isActiveInScene);
    }
}
