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


    void Awake()
    {
        UIInputActions= new InputActions();
        UIInputActions.UI_Base.Enable();
        PlayerController.Instance.DisablePlayerControls();
        eventSystem=EventSystem.current;
        UIInputActions.UI_Base.Action.performed+=Action_Performed;      
    }
    // Start is called before the first frame update
    void Start()
    {
        //ExteriorUI.onPopUpMessageCalled+=ExteriorUI_OnMenuCalled;
        eventSystem.firstSelectedGameObject=firstSelectedButton.gameObject;
        eventSystem.SetSelectedGameObject(firstSelectedButton.gameObject);
        ShopNPC.OnMenuClosed+=ShopNPC_OnMenuClosed;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExteriorUI_OnMenuCalled(object sender, EventArgs empty)
    {
        eventSystem.firstSelectedGameObject=firstSelectedButton.gameObject;
    }

    public void Action_Performed(InputAction.CallbackContext context)
    {
        //Debug.Log("UI Action Called");
        currentSelected=eventSystem.currentSelectedGameObject;
        if(currentSelected!=null)
        {
            Button currentButton=currentSelected.GetComponent<Button>();
            currentButton.onClick.Invoke();
        }    
    }

    public void ShopNPC_OnMenuClosed(object sender, EventArgs empty)
    {
        UIInputActions.UI_Base.Disable();
    }


}
