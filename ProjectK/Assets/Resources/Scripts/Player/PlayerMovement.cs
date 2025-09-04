using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float rightLeft, Forward;
    Vector3 direction;
    Vector3 movement = Vector3.zero;

    [SerializeField]
    float speed;
    Rigidbody rb;
    // Start is called before the first frame update


    [SerializeField]
    public  bool fighting = false;


    [SerializeField]
    float rotationSpeed;


    CharacterController cc;

    [SerializeField]
    Vector3 gravity;
    float gravityValue = 9.81f;


    bool isGrounded;

    [SerializeField]
    bool Menu = false;



    void Start()
    {
        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = cc.isGrounded;

        if (isGrounded && gravity.y < 0)
        {
            gravity.y = -2f;
        }

        if (!fighting || Menu)
        {
            OutOfFight();
        }






    }

    void OutOfFight()
    {
        rightLeft = Input.GetAxisRaw("Horizontal");
        Forward = Input.GetAxisRaw("Vertical");
        direction = new Vector2(rightLeft, Forward);

        MovePlayer();
        Rotation();

        if (direction != Vector3.zero)
        {
            speed = 8;
        }
        else { speed = 0; }

        //transform.Translate(movement *speed* Time.deltaTime);

        cc.Move(movement * speed * Time.deltaTime);

        Gravity();

        cc.Move(gravity * Time.deltaTime);
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

    void Rotation()
    {
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);//rotation speed base value 400f

        }
    }

    void Gravity()
    {
        gravity.y -= gravityValue * Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        /*Debug.Log("stayy");

        if (other.CompareTag("Menu"))
        {
            if (Input.GetButtonDown("Interact"))
            {

            }



        }*/
    }

}
