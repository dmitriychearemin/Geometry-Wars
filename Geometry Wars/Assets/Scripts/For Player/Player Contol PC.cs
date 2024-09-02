using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class PlayerContolPC : MonoBehaviour
{
    [SerializeField] float playerSpeed = 3;

    private CharacterController controller;
    // Start is called before the first frame update 
    private bool onGround = true;
    Rigidbody rb;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame 
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * horizontal + transform.forward * vertical;

        if(onGround == true)
        controller.Move(movement * playerSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && onGround == true)
        {
            onGround = true;
            //rb.velocity = new Vector3(movement.x, movement.y + 100,movement.z);
           // rb.velocity = new Vector3(0, 5, 0);
            rb.AddForce(movement * 5 * Time.deltaTime);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            print("fdhdfh");
            onGround = true;
        }
    }

}
