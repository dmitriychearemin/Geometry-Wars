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
    [SerializeField] float dashSpeed = 30;
    [SerializeField] float dashTime= 0.3f;
    [SerializeField] AnimationCurve dashCurve;
    private CharacterController controller;
  
    InterractionPlayer playerInteraction;

    private bool onGround = true;
    bool isDashing = false;
    bool isRegeniratingStamina = true;

    private Vector3 velocity;
    Vector3 movement;

    Transform checkGround;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    


    void Start()
    {

        playerInteraction = GetComponent<InterractionPlayer>();
        controller = GetComponent<CharacterController>(); 
        checkGround = GameObject.Find("CheckGround").transform;
        
    }

    void Update()
    {
        Actions();
    }

    private IEnumerator Dash()
    {
        
        if (isDashing) yield break;
        isDashing = true;
        var elapsedTime = 0f;
        while (elapsedTime < dashTime)
        {
            var velocityMultiplier = dashSpeed * dashCurve.Evaluate(elapsedTime);

            controller.Move((movement * playerSpeed * velocityMultiplier * Time.deltaTime)); 
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        isDashing = false;
        yield break;
    }

    void Actions()
    {
        if (onGround && !isDashing && !playerInteraction.CheckOnFullStamina())
        {
            playerInteraction.RegeneratingStamina();
        }

        onGround = Physics.CheckSphere(checkGround.position, groundDistance, groundMask);

        if (onGround && velocity.y <= 0)
        {
            velocity.y = -1;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Dash"))
        {
            if (playerInteraction.DecreaseStamina(70))
            {
                isRegeniratingStamina = false;
                StartCoroutine(Dash());
            }


        }

        movement = transform.right * horizontal + transform.forward * vertical;
        controller.Move((movement * playerSpeed * Time.deltaTime));
        velocity.y += gravity * 2 * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            if (playerInteraction.DecreaseStamina(60))
            {
                isRegeniratingStamina = false;
                velocity.y += HighJump;
            }

        }
    }
}
