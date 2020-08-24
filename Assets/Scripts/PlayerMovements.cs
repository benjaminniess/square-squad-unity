﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovements : MonoBehaviour
{
    public float reactorForce;

    private bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rightReactor;
    public Rigidbody2D leftReactor;

    public Joystick leftJoystick;
    public Joystick rightJoystick;

    public Rigidbody2D rb;

    public GameObject topCenterPoint;
    public GameObject bottomCenterPoint;
    public Vector2 currentVectorLeft;
    public Vector2 currentVectorRight;

    

    private Vector3 lastPosition = Vector3.zero;
    private float speed;
    private float rotationSpeed;
    private float rotationLast = 0;
    private float rotationDelta;

    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    void Update()
    {
        // Speed calculation
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;

        // Rotation calculation
        float currentRotation = transform.rotation.eulerAngles.z;
        if ( currentRotation > 180 ) {
            currentRotation = - (360 - currentRotation );
        }

        // Rotation delta calculation
        rotationDelta = currentRotation - rotationLast;
        rotationLast = currentRotation;
        rotationDelta = rotationDelta < 0 ? -rotationDelta : rotationDelta;

        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        currentVectorRight = ( topCenterPoint.transform.position - groundCheckRight.transform.position ).normalized;
        currentVectorLeft = ( topCenterPoint.transform.position - groundCheckLeft.transform.position ).normalized;


        // = new Vector2( - leftJoystick.Horizontal,  leftJoystick.Vertical < 0 ? -leftJoystick.Vertical : 0 ).normalized;
        //currentVectorLeft = new Vector2(  - rightJoystick.Horizontal,  rightJoystick.Vertical < 0 ? -rightJoystick.Vertical : 0 ).normalized;
        
        //Debug.Log(leftJoystick.Vertical);

        float rightReactorLevel = getRightReactorLevel();
        float leftReactorLevel = getLeftReactorLevel();

        if ( rightReactorLevel == 0 && leftReactorLevel == 0 ) {
            //rb.MoveRotation( 0f - (currentRotation / 4500 ));
            //rb.velocity = rb.velocity * 0.8f; 
        }

        if ( rightReactorLevel > 0 ) {
            rightReactor.AddForce(currentVectorRight * reactorForce * Time.deltaTime * rightReactorLevel); 
        } else if ( rightReactorLevel < 0 ) {
            rb.AddTorque(Time.deltaTime * rightReactorLevel * 1000);
        }

        if ( leftReactorLevel > 0 ) {
            leftReactor.AddForce(currentVectorLeft * reactorForce * Time.deltaTime * leftReactorLevel);
        } else if ( leftReactorLevel < 0 ) {
            rb.AddTorque(Time.deltaTime * -leftReactorLevel * 1000);
        }
    

        

        
        //rightReactor.AddForce( new Vector2( bottomCenterPoint.transform.position, groundCheckRight.transform.position ).normalized * (reactorForce / 10) * Time.deltaTime * rightJoystick.Horizontal);
        //leftReactor.AddForce( new Vector2( bottomCenterPoint.transform.position, groundCheckLeft.transform.position ).normalized * (reactorForce / 10) * Time.deltaTime * leftJoystick.Horizontal);
    }

    float getRightReactorLevel() {
        if ( Input.GetKey("right") == true ) {
            return 1f;
        }
        return rightJoystick.Vertical;
    }

    float getLeftReactorLevel() {  
        if ( Input.GetKey("left") == true ) {
            return 1f;
        }
        return leftJoystick.Vertical;
    }
}
