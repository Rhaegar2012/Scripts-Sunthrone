using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    [SerializeField] private float forceMagnitude;
    void Awake()
    {
        playerRigidBody= GetComponent<Rigidbody2D>();
    }

    public  void Movement()
    {
        Debug.Log("Player movement");
       
    }



}
