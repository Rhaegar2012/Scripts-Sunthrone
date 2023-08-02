using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class InputController : MonoBehaviour
{
    private InputActions UIInputActions;
    private EventSystem eventSystem;
    [SerializeField] Button firstSelectedButton;
    private GameObject currentSelected;
    //Events
    public static event EventHandler onMenuClosed;


    void Awake()
    {
        UIInputActions= new InputActions();
        PlayerController.Instance.DisablePlayerControls();
        eventSystem=EventSystem.current;
        UIInputActions.UI_Base.Action.performed+=Action_Performed; 
        UIInputActions.UI_Base.CloseMenu.performed+=PauseMenu_Closed;    
    }
    // Start is called before the first frame update
    void Start()
    {
        ShopNPC.OnMenuClosed+=ShopNPC_OnMenuClosed;
        CommanderNPC.OnMenuClosed+=CommanderNPC_OnMenuClosed;    
    }

    void OnEnable()
    {
        eventSystem.firstSelectedGameObject=firstSelectedButton.gameObject;
        eventSystem.SetSelectedGameObject(firstSelectedButton.gameObject);
        PlayerController.Instance.DisablePlayerControls();
        UIInputActions.UI_Base.Enable();
    }

    public void ExteriorUI_OnMenuCalled(object sender, EventArgs empty)
    {
        eventSystem.firstSelectedGameObject=firstSelectedButton.gameObject;
    }

    public void Action_Performed(InputAction.CallbackContext context)
    {
        Debug.Log("Call Action Performed");   
        currentSelected=eventSystem.currentSelectedGameObject;
        if(currentSelected!=null)
        {
            Button currentButton=currentSelected.GetComponent<Button>();
            currentButton.onClick.Invoke();
        }    
    }

    public void PauseMenu_Closed(InputAction.CallbackContext context)
    {
        PlayerController.Instance.EnablePlayerControls();
        onMenuClosed?.Invoke(this,EventArgs.Empty);

    }

    public void ShopNPC_OnMenuClosed(object sender, EventArgs empty)
    {
        UIInputActions.UI_Base.Disable();
        PlayerController.Instance.EnablePlayerControls();
    }

    public void CommanderNPC_OnMenuClosed (object sender , EventArgs empty)
    {
        UIInputActions.UI_Base.Disable();
        PlayerController.Instance.EnablePlayerControls();
    }




}
