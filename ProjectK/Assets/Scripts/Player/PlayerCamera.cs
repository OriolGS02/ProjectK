using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float Sensitivity = 10;
    public Transform target;
    public float distance = 6;

    float x;
    float y;

    Vector2 clampY = new Vector2(-10, 80);

    public float smoothRotationTime = 0.12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        x += Input.GetAxis("Mouse X") * Sensitivity;
        y -= Input.GetAxis("Mouse Y") * Sensitivity;

        y = Mathf.Clamp(y, clampY.x, clampY.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(y, x), ref rotationSmoothVelocity, smoothRotationTime);


        transform.eulerAngles = currentRotation;

        transform.position = target.position - transform.forward * distance;


        if (distance < 7 && Input.mouseScrollDelta.y > 0)
        {
            distance += Input.mouseScrollDelta.y * 0.5f;
        }
        if (distance > 2.5 && Input.mouseScrollDelta.y < 0)
        {
            distance += Input.mouseScrollDelta.y * 0.5f;
        }

    }
}
