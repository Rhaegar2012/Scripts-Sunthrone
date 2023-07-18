using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class UnitActionMenuController : MonoBehaviour
{
    private InputActions UIInputActions;
    private EventSystem eventSystem;
    [SerializeField] Button firstSelectedButton;
    private GameObject currentSelected;

    void Awake()
    {
        UIInputActions= new InputActions();
        UIInputActions.UI_Base.Action.performed+=Action_Performed ;
    }

    public void OnEnable()
    {
        eventSystem.firstSelectedGameObject=firstSelectedButton.gameObject;
        eventSystem.SetSelectedGameObject(firstSelectedButton.gameObject);
        UnitSelectorController.Instance.DisableSelectorController();
    }

    public void Action_Performed(InputAction.CallbackContext context)
    {
        currentSelected=eventSystem.currentSelectedGameObject;
        if(currentSelected!=null)
        {
            Button currentButton=currentSelected.GetComponent<Button>();
            currentButton.onClick.Invoke();
            UnitSelectorController.Instance.EnableSelectorController();
        }
        
    }
}
