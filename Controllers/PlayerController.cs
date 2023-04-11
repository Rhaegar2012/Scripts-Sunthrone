using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    //Instance of player input action class, generate from input action asset before calling
    private InputActions playerInputActions;
    [SerializeField] private float speed;

    void Awake()
    {
        playerRigidBody= GetComponent<Rigidbody2D>();
        playerInputActions= new InputActions();
        //Enable Player_Base action map
        playerInputActions.Player_Base.Enable();
        
    }
    void Update()
    {
        
        Vector2 movementDirection=playerInputActions.Player_Base.Movement.ReadValue<Vector2>();
        Vector3 offsetPosition=transform.position+new Vector3(movementDirection.x,movementDirection.y,0f);
        if(LevelGrid.Instance.CheckPositionValid(offsetPosition))
        {
            PlayerMovement(movementDirection);
        }
        else
        {
            PlayerMovement(new Vector2(0f,0f));
        }
    }

    void PlayerMovement(Vector2 movementDirection)
    {
       
        playerRigidBody.velocity= new Vector2(movementDirection.x*speed,movementDirection.y*speed);

    }
  




}
