using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class UnitActionMenuController : MonoBehaviour
{
    //Events
    public static event EventHandler OnActionCalled;
    //Fields
    private InputActions UIInputActions;
    private EventSystem eventSystem;
    [SerializeField] Button firstSelectedButton;
    private GameObject currentSelected;
    

    void Awake()
    {
        UIInputActions= new InputActions();
        eventSystem=EventSystem.current;
        UIInputActions.UI_Base.Action.performed+=Action_Performed;
        
    }

    void Start()
    {
        
        UnitActionSystem.Instance.OnActionPositionSelected+=UnitActionSystem_EnableActionMenuControls;
    }

    public void UnitActionSystem_EnableActionMenuControls(object sender, EventArgs empty)
    {
        UIInputActions.UI_Base.Enable();
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
            UIInputActions.UI_Base.Disable();
            UnitSelectorController.Instance.EnableSelectorController();
            OnActionCalled?.Invoke(this,EventArgs.Empty);

        }
        
    }
}
