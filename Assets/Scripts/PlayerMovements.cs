﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovements : MonoBehaviour
{
    private float speed = 19;
    private int score = 0;
    private float acceleration = 750;
    float deceleration = 700;
    private Vector2 velocity;
    private bool isTrackedVal = true;
    private bool isHoldingCoinVal = false; 
    private GameObject fakeCoin;

    private Vector2 playerStartPos;

    PlayerController controls;

    public string upTouch;
    public string leftTouch;
    public string rightTouch;
    public string downTouch;

    private bool upButton = false;
    private bool downButton = false;
    private bool leftButton = false;
    private bool rightButton = false;
    float ControllerMove;

    void Awake() {
        controls = new PlayerController();
        controls.Gameplay.UP.performed += ctx => upButton = true;
        controls.Gameplay.UP.canceled += ctx => upButton = false;
        controls.Gameplay.DOWN.performed += ctx => downButton = true;
        controls.Gameplay.DOWN.canceled += ctx => downButton = false;
        controls.Gameplay.LEFT.performed += ctx => leftButton = true;
        controls.Gameplay.LEFT.canceled += ctx => leftButton = false;
        controls.Gameplay.RIGHT.performed += ctx => rightButton = true;
        controls.Gameplay.RIGHT.canceled += ctx => rightButton = false;
    }

    void OnEnable() {
        controls.Gameplay.Enable();
    }

    void OnDisable() {
        controls.Gameplay.Enable();
    }

    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        playerStartPos = transform.position;
        fakeCoin = transform.Find("FakeCoin").gameObject;
        //fakeCoin.SetActive(false);
    }

    public void resetStartPos() {
        transform.position = playerStartPos;
        if ( isHoldingCoin() ) {
            setIsHoldingCoin(false);
            Main.instance.GenerateCoin();
        }
    }

    public void increaseScore() {
        score++;
    }

    public void decreaseScore() {
        score--;
        if ( score < 0 ) {
            score = 0;
        }
    }

    public int getScore() {
        return score;
    }

    public bool isTracked(){
        return isTrackedVal;
    }

    public void setTracked(bool isTracked) {
        isTrackedVal = isTracked;
    }

    public bool isHoldingCoin(){
        return isHoldingCoinVal;
    }

    public void setIsHoldingCoin(bool isHoldingCoin) {
        fakeCoin.SetActive(isHoldingCoin);
        isHoldingCoinVal = isHoldingCoin;
    }

    void FixedUpdate() {
        if ( getHorizontalAxe() != 0 ) {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * getHorizontalAxe(), acceleration * Time.deltaTime);
        } else {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        if ( getVerticalAxe() != 0 ) {
            velocity.y = Mathf.MoveTowards(velocity.y, speed * getVerticalAxe(), acceleration * Time.deltaTime);
        } else {
            velocity.y = Mathf.MoveTowards(velocity.y, 0, deceleration * Time.deltaTime);
        }

        transform.Translate(velocity * Time.deltaTime);
    }

    void OnTriggerEnter2D (Collider2D collider) {
        // TODO: Check dash system
        if ( isHoldingCoin() ) {
            if (collider.tag == "Player" ) {
                PlayerMovements playerScript = collider.gameObject.GetComponent<PlayerMovements>();
                playerScript.setIsHoldingCoin(true);
                setIsHoldingCoin(false);
            }
        }
    }

    float getHorizontalAxe() {
        if ( Input.GetKey(leftTouch) == true ) {
            return -1f;
        }

        if ( Input.GetKey(rightTouch) == true ) {
            return 1f;
        }

        if ( rightButton ) {
            return 1f;
        }

        if ( leftButton ) {
            return -1f;
        }

        return 0f;
    }

    float getVerticalAxe() {
        if ( Input.GetKey(upTouch) == true ) {
            return 1f;
        }

        if ( Input.GetKey(downTouch) == true ) {
            return -1f;
        }

        if ( upButton ) {
            return 1f;
        }

        if ( downButton ) {
            return -1f;
        }

        return 0f;
    }
}
