using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    [SerializeField] private string menuName;
    public string MenuName{get{return menuName;}set{menuName=value;}}
    public void ActivateMenu()
    {
        gameObject.SetActive(true);
    }
    public void DeactivateMenu()
    {
        gameObject.SetActive(false);
    }
}
