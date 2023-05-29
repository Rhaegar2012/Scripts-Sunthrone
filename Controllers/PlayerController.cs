using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : SingletonMonobehaviour<PlayerController>
{

    //Member Variables
    private Rigidbody2D playerRigidBody;
    private Animator playerAnimator;
    private Sprite playerSprite;
    private bool isPlayerMoving;
    [SerializeField] private float speed;
    //Instance of player input action class, generate from input action asset before calling
    private InputActions playerInputActions;
    //Active Construction sign
    private BuildingSystem activeConstructionSign;
    public  BuildingSystem ActiveConstructionSign{get{return activeConstructionSign;}set{activeConstructionSign=value;}}
    //Active Shop Reference
    private ShopNPC activeShopNPC;
    public  ShopNPC ActiveShopNPC {get{return activeShopNPC;} set{activeShopNPC=value;}}
    //Events
    public  event EventHandler<BuildingSystem> onPopupCalled;
    public  event EventHandler<ShopNPC> onShopMenuCalled;
    public  event EventHandler onPauseMenuCalled;
    
    protected override void Awake()
    {
        base.Awake();
        className="Player Controller";
        playerRigidBody= GetComponent<Rigidbody2D>();
        playerAnimator=GetComponent<Animator>();
        playerSprite=GetComponent<SpriteRenderer>().sprite;
        playerInputActions= new InputActions();
        //Enable Player_Base action map
        playerInputActions.Player_Base.Enable();
        //Subscribe to action event
        playerInputActions.Player_Base.Action.performed+=Action_Performed;
        playerInputActions.Player_Base.Menu.performed+=Pause_Menu;
        DontDestroyOnLoad(gameObject);
    
    }
    void Update()
    {
        
        Vector2 movementDirection=playerInputActions.Player_Base.Movement.ReadValue<Vector2>();
        if(movementDirection!=Vector2.zero)
        {
            isPlayerMoving=true;
        }
        else
        {
            isPlayerMoving=false;
        }
        PlayerMovement(movementDirection);
        
    }

    void PlayerMovement(Vector2 movementDirection)
    {
        //Allows movement only in one direction (no diagonal)
        if(movementDirection.x!=0 && movementDirection.y!=0)
        {
            return;
        }
        //Checks that player is not outside grid limits
        Vector3 offsetPosition=transform.position+new Vector3(movementDirection.x,movementDirection.y,0f);
        if(!LevelGrid.Instance.CheckPositionValid(offsetPosition))
        {
            playerRigidBody.velocity= new Vector2 (0f,0f);
            return;
        }
        playerRigidBody.velocity= new Vector2(movementDirection.x*speed,movementDirection.y*speed);
        //Animation parameter setup
        if(movementDirection.x!=0)
        {
           
            SetPlayerAnimation("moveX",movementDirection.x,isPlayerMoving);
            SetPlayerAnimation("moveY",0f,isPlayerMoving);
            transform.localScale=new Vector3(-movementDirection.x,1f,1f);
        }
        if(movementDirection.y!=0)
        { 
            SetPlayerAnimation("moveY",movementDirection.y,isPlayerMoving);
            SetPlayerAnimation("moveX",0f,isPlayerMoving);
        }
        //Return to idle state
        if(!isPlayerMoving)
        {
            SetPlayerAnimation("isMoving",0f,isPlayerMoving); 
        }
        
    }

    void SetPlayerAnimation(string animationParameter,float direction,bool isMoving)
    {
        if(isMoving)
        {
            playerAnimator.SetFloat(animationParameter,direction);
            playerAnimator.SetBool("isMoving",isMoving);
        }
        else
        {
            playerAnimator.SetBool(animationParameter,isMoving);
        }
        
    }

    void Action_Performed(InputAction.CallbackContext context)
    {
        if(activeConstructionSign!=null)
        {   
            onPopupCalled?.Invoke(this,activeConstructionSign);
        }

        if(activeShopNPC!=null)
        {
            onShopMenuCalled?.Invoke(this,activeShopNPC);
        }
    }

    void Pause_Menu(InputAction.CallbackContext context)
    {
        onPauseMenuCalled?.Invoke(this,EventArgs.Empty);
        DisablePlayerControls();
    }

    public void DisablePlayerControls()
    {
        playerInputActions.Player_Base.Disable();
    }

    public void EnablePlayerControls()
    {
        playerInputActions.Player_Base.Enable();
    }
    
    
  




}
