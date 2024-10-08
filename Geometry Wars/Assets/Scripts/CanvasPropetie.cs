using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Ui;

public class CanvasPropetie : MonoBehaviour
{
    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.renderMode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
