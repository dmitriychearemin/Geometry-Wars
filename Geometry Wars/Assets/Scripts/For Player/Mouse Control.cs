using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl: MonoBehaviour
{

    [SerializeField] float mouseX;
    [SerializeField] float mouseY;
    [SerializeField] float MouseSens = 65;
    [SerializeField] private float xRotation;
    Transform playerBody;

    private void Start()
    {
        playerBody = GameObject.Find("Player").GetComponent<Transform>();
        
    }

    private void Update()
    {

        mouseX = Input.GetAxis("Mouse X") * MouseSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * MouseSens * Time.deltaTime;

        xRotation -= mouseY;
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        playerBody.Rotate(Vector3.up * mouseX);
    }

}
