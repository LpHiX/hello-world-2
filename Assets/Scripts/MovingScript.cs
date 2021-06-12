using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    Rigidbody rigidbody;
    public float movementSpeed = 1f;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Jump");
        float zInput = Input.GetAxis("Vertical");

        Vector3 moveDir = (new Vector3(xInput, yInput, zInput).normalized);
        moveAmount = moveDir * movementSpeed;
        
        //moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
    }

        void FixedUpdate()
    {
        rigidbody.velocity = transform.TransformDirection(moveAmount) + rigidbody.velocity;
        //rigidbody.MovePosition(rigidbody.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
}
