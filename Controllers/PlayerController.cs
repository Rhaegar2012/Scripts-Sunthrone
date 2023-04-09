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
        playerRigidBody.velocity=new Vector2(movementDirection.x*speed,movementDirection.y*speed);

    }
  




}
