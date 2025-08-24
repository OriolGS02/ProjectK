using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    float rightLeft,Forward;
    Vector3 direction;
    Vector3 movement=Vector3.zero;

    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rightLeft = Input.GetAxis("Horizontal");
        Forward = Input.GetAxis("Vertical");
        direction = new Vector2(rightLeft, Forward);

        MovePlayer();
        Rotation();

        if (movement!=Vector3.zero) 
        {
            speed = 8;
        }
        else { speed = 0; }

        transform.Translate(movement *speed* Time.deltaTime);
       
       
       


        


    }

    void MovePlayer() 
    {
        Vector3 forwardCam = Camera.main.transform.forward;
        Vector3 rightCam = Camera.main.transform.right;


        forwardCam.y = 0;
        rightCam.y = 0;
        forwardCam.Normalize();
        rightCam.Normalize();

        movement = forwardCam * Forward + rightCam * rightLeft;
        movement.Normalize();
    }

    void Rotation ()
    {
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 400f * Time.deltaTime);

        }
    }
}
