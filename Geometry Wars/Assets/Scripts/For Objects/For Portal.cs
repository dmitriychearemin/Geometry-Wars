using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ForPortal : MonoBehaviour
{
    sceneManager scene;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        scene = GetComponent<sceneManager>();
        player = GameObject.Find("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
       
            if (name == "PortalSurvivalMode")
            {
                
                scene.openSurvivalMode();
            }
        }
    }

}
