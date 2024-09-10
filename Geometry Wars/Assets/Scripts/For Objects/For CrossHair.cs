using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForCrossHair : MonoBehaviour
{

    float actionRange = 10; // будет передаваться дистанция досягаемости оружия до противника

    bool ActiveCrosshair = false;
    float activeAlphaCrosshair = 1;
    float  disactiveAlphaCrosshair = 0.6f;
    [SerializeField] Camera camera;
    Vector4 color;

    // Start is called before the first frame update
    void Start()
    {
       
        color = gameObject.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit raycastHit;
        int layerMask = 1 << 9;

        layerMask = ~layerMask;
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, layerMask))
        {

            if (raycastHit.distance <= actionRange && raycastHit.collider.tag == "Enemy")
            {
                if (ActiveCrosshair)
                { 
                    gameObject.GetComponent<Image>().color = new Vector4(color.x,color.y, color.z, disactiveAlphaCrosshair);
                    ActiveCrosshair = false;
                }
            }

            else
            {
                if (!ActiveCrosshair)
                {
                    gameObject.GetComponent<Image>().color = new Vector4(color.x, color.y, color.z, activeAlphaCrosshair);
                }

                ActiveCrosshair = true;
            }
        }

        else
        {
            if (!ActiveCrosshair)
            {
                gameObject.GetComponent<Image>().color = new Vector4(color.x, color.y, color.z, activeAlphaCrosshair);
            }
            ActiveCrosshair = true;
        }
        

    }
}
