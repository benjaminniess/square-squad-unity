using UnityEngine;
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
    private GameObject dashStatus;

    private Vector2 playerStartPos;

    PlayerController controls;


    // DASH SYSTEM
    float dashTimer = 0.0f;
    float dashSleepTimer = 0.0f;
    public float dashDuration = 0.5f;
    public float dashSleepDuration = 2f;
    private bool isDashing = false;

    // KO SYSTEM
    float koTimer = 0.0f;
    public float koDuration = 1f;
    private bool isKOVal = false;

    public string upTouch;
    public string leftTouch;
    public string rightTouch;
    public string downTouch;
    public string dashTouch;

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
           // score = 0;
        }
    }

    public int getScore() {
        return score;
    }

    public bool isTracked(){
         if ( isKO() ) {
            return false;
        }
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
        if ( isKO() ) {
            koTimer += Time.deltaTime;
            
            // Disable dash so the user can't dash right after ko
            dashSleepTimer = 0;

            return;
        } else {
            koTimer = 0;
            isKOVal = false;
        }

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

    
        dashStatus = transform.Find("DashStatus").gameObject;
        dashStatus.SetActive( isDashAvailable() );
        
        if (getDashStatus() == true) {
            dashTimer += Time.deltaTime;
            velocity *= 1.7f;
            
        } else {
            dashSleepTimer += Time.deltaTime;
        }

        transform.Translate(velocity * Time.deltaTime);
    }

    void OnTriggerEnter2D (Collider2D collider) {
        if ( isHoldingCoin() ) {
            if (collider.tag == "Player" ) {
                PlayerMovements playerScript = collider.gameObject.GetComponent<PlayerMovements>();
                if ( playerScript.isDashing ) {
                    playerScript.setIsHoldingCoin(true);
                    setIsHoldingCoin(false);
                }
            }
        }
    }

    bool isDashAvailable() {
        if ( isDashing ) {
            return false;
        }

        // Disable dash when holding coin
        if ( isHoldingCoin() ) {
            return false;
        }

        if ( dashSleepTimer < dashSleepDuration ) {
            return false;
        }

        return true;
    }

    bool getDashStatus() {
        // No dashing, no dash button
        if ( ! isDashing && ! Input.GetKey(dashTouch) ) {
            return false;
        }

        // Dashing time expiration
        if ( isDashing && dashTimer > dashDuration ) {
            isDashing = false;
            dashTimer = 0;
            dashSleepTimer = 0;
            return false;
        }

        // Dash engoing
        if ( isDashing && dashTimer < dashDuration ) {
            return true;
        }

        // New dash
        if ( Input.GetKey(dashTouch) && isDashAvailable() ) {
            isDashing = true;
            return true;
        }

        return false;
    }

    public bool isKO() {
        if ( ! isKOVal ) {
            return false;
        }

        if ( koTimer > koDuration ) {
            return false;
        }

        return true;
    }

    public bool setKO() {
        if ( ! isKOVal ) {
            isKOVal = true;
            koTimer = 0;

            return true;
        }

        return false;
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
