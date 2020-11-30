using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    float camSens = 0.25f;
    private Vector3 startPos;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            startPos = Input.mousePosition;
        else if (Input.GetMouseButton(1))
        {
            startPos = Input.mousePosition - startPos;
            startPos = new Vector3(-startPos.y * camSens, startPos.x * camSens, 0);
            startPos = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + startPos.y, 0);
            transform.eulerAngles = startPos;
            startPos = Input.mousePosition;
        }
    }
}
