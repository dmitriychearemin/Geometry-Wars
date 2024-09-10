using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForCamera : MonoBehaviour
{

    Camera camera; // —сылка на камеру
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        /*Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance <= 0.2 && hit.collider.tag == "Weapon")
            {
                print("da");
                hit.collider.GetComponent<MeshRenderer>().enabled = false;
            }

            else
            {
                hit.collider.GetComponent<MeshRenderer>().enabled = true;
            }
        }*/


    }




}
