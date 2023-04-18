using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] private GameObject constructionYard;
    [SerializeField] private GameObject newBuilding;

    

    public void ConstructNewBuilding()
    {
        constructionYard.SetActive(false);
        newBuilding.SetActive(true);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController.Instance.ActiveConstructionSign=this;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerController.Instance.ActiveConstructionSign=null;
    }
}
