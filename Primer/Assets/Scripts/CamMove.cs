using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform cameraTransform;
    public float movementSpeed;
    public float movementTime;
    public Vector3 zoomAmount;

    public Vector3 newPosition;
    public Vector3 newZoom;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public Vector2 LimitMove;
    public float MinY, MaxY;

    //private BoxCollider box;

    void Start()
    {
        //GameObject obj1 = GameObject.Find("Parking (0)");
        //box = obj1.GetComponent<BoxCollider>();

        newPosition = transform.position;
        newZoom = cameraTransform.localPosition;
    }

    void Update()
    {
        HandleMouseInput();
        HandleMovementInput();

        newPosition.x = Mathf.Clamp(newPosition.x, -LimitMove.x, LimitMove.x);
        newPosition.z = Mathf.Clamp(newPosition.z, -LimitMove.y, LimitMove.y);

        newZoom.y = Mathf.Clamp(newZoom.y, MinY, MaxY);
        newZoom.z = Mathf.Clamp(newZoom.z, MinY, MaxY);
    }

    void HandleMouseInput()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }

        //if (box.enabled == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Plane plane = new Plane(Vector3.up, Vector3.zero);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                float entry;
                if(plane.Raycast(ray, out entry))
                {
                    dragStartPosition = ray.GetPoint(entry);
                }
            }
            if (Input.GetMouseButton(0))
            {
                Plane plane = new Plane(Vector3.up, Vector3.zero);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                float entry;
                if(plane.Raycast(ray, out entry))
                {
                    dragCurrentPosition = ray.GetPoint(entry);
                    newPosition = transform.position + dragStartPosition - dragCurrentPosition;
                }
            }
        }
    }

    void HandleMovementInput()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementSpeed);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);

    }
}
