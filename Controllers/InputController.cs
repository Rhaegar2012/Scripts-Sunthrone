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

    void Awake()
    {
        UIInputActions= new InputActions();
        UIInputActions.Player_Base.Enable();
        eventSystem=EventSystem.current;
        UIInputActions.Player_Base.Action.performed+=Action_Performed;
            
    }
    // Start is called before the first frame update
    void Start()
    {
        ExteriorUI.onPopUpMessageCalled+=ExteriorUI_OnMenuCalled;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExteriorUI_OnMenuCalled(object sender, EventArgs empty)
    {
        eventSystem.SetSelectedGameObject(firstSelectedButton.gameObject);
    }

    public void Action_Performed(InputAction.CallbackContext context)
    {
        Debug.Log("Action Called");
        firstSelectedButton.onClick.Invoke();
        
    }
}
