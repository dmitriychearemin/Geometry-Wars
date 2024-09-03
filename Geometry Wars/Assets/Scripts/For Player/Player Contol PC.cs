using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerContolPC : MonoBehaviour
{
    [SerializeField] float playerSpeed = 3;
    [SerializeField] float HighJump = 30;
    [SerializeField] float gravity = -100f;
    private CharacterController controller;
   

    private bool onGround = true;
    
    private Vector3 velocity;

    Transform checkGround;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;


    void Start()
    {
        controller = GetComponent<CharacterController>(); 
        checkGround = GameObject.Find("CheckGround").transform;
        

    }


    // Update is called once per frame 
    void Update()
    {
        onGround = Physics.CheckSphere(checkGround.position,groundDistance,groundMask);
        print(onGround);

        if(onGround && velocity.y <= 0)
        {
            velocity.y = -1;
            
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * horizontal + transform.forward * vertical;

     
        controller.Move(movement * playerSpeed * Time.deltaTime);

        velocity.y += gravity*2 * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            velocity.y += HighJump;
        }
    }

}
