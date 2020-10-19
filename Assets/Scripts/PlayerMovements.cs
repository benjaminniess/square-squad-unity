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

    private string playerHealth = "ok";
    
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
    private GameObject koStatus;
    private GameObject recoverStatus;

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
        koStatus = transform.Find("KOStatus").gameObject;
        dashStatus = transform.Find("DashStatus").gameObject;
        recoverStatus = transform.Find("RecoverStatus").gameObject;
    }

    public int getScore() {
        return score;
    }

    public string getPlayerHealth() {
        return playerHealth;
    }

    public bool isOk() {
        return getPlayerHealth() == "ok";
    }

    public bool isRecovering() {
        return getPlayerHealth() == "recovering";
    }

    public bool isKO() {
        return getPlayerHealth() == "ko";
    }

    public bool isDashAvailable() {
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

    public bool isTracked(){
        if ( isKO() ) {
            return false;
        }

        if ( isRecovering() ) {
            return false;
        }

        return isTrackedVal;
    }

    public bool isHoldingCoin(){
        return isHoldingCoinVal;
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

    public void setTracked(bool isTracked) {
        isTrackedVal = isTracked;
    }

    public bool setKO() {
        if ( ! isKO() ) {
            playerHealth = "ko";
            koTimer = 0;

            koStatus.SetActive( true );

            return true;
        }

        return false;
    }

    public void setOK() {
        koTimer = 0;
        playerHealth = "ok";
        koStatus.SetActive( false );
        recoverStatus.SetActive( false );
    }

    public void setRecovering() {
        koTimer = 0;
        playerHealth = "recovering";
        koStatus.SetActive( false );
        recoverStatus.SetActive( true );
    }

    public void setIsHoldingCoin(bool isHoldingCoin) {
        fakeCoin.SetActive(isHoldingCoin);
        isHoldingCoinVal = isHoldingCoin;
    }

    public void updatePlayerStatus() {
        koTimer += Time.deltaTime;

        if ( isKO() ) {
            // Disable dash so the user can't dash right after ko
            dashSleepTimer = 0;

            if ( koTimer > koDuration ) {
                setRecovering();
            }

            return;
        } else if ( isRecovering() ){
            if ( koTimer > koDuration ) {
                setOK();
            }
        }
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

    void FixedUpdate() {
        updatePlayerStatus();
        if ( isKO() ) {
            return;
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
                    setKO();
                }
            }
        }
    }
}
