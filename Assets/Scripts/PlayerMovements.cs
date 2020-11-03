using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovements : MonoBehaviour
{

    private float currentSpeed;
    private int score = 0;
    private int playerNumber;
    private Rigidbody2D rb;
    private bool isTrackedVal = true;

    private string playerHealth = "ok";

    private bool isHoldingCoinVal = false;
    private GameObject fakeCoin;
    private GameObject dashStatus;

    private Vector2 playerStartPos;

    PlayerController controls;

    private float speed = 1000;
    private float currentPlayerSpeed;

    // DASH SYSTEM
    float dashTimer = 0.0f;
    float dashSleepTimer = 0.0f;
    private float dashDuration = 0.05f;
    private float dashSpeed = 3000;
    private float dashSleepDuration = 2;
    private bool isDashingVal = false;

    // KO SYSTEM
    float koTimer = 0.0f;
    private float koDuration = 1f;
    private GameObject koStatus;
    private GameObject recoverStatus;

    // BONUS SYSTEM
    private bool isHoldingBonusVal = false;
    private bool isUsingBonusVal = false;
    private Bonus bonus;
    private Bonus stashedBonus;
    private float bonusTimer;

    private bool upButton = false;
    private bool downButton = false;
    private bool leftButton = false;
    private bool rightButton = false;
    private bool dashButton = false;
    private bool bonusButton = false;
    private bool startButton = false;
    private bool northButton = false;
    private bool southButton = false;

    private SpriteRenderer playerColor;

    public void pressUp(InputAction.CallbackContext ctx)
    {
        upButton = 0.1f < ctx.ReadValue<float>() ? true : false;
    }

    public void pressDown(InputAction.CallbackContext ctx)
    {
        downButton = 0.1f < ctx.ReadValue<float>() ? true : false;
    }

    public void pressLeft(InputAction.CallbackContext ctx)
    {
        leftButton = 0.1f < ctx.ReadValue<float>() ? true : false;
    }

    public void pressRight(InputAction.CallbackContext ctx)
    {
        rightButton = 0.1f < ctx.ReadValue<float>() ? true : false;
    }

    public void pressDash(InputAction.CallbackContext ctx)
    {
        dashButton = 1 == ctx.ReadValue<float>() ? true : false;
    }

    public void pressBonus(InputAction.CallbackContext ctx)
    {
        bonusButton = 1 == ctx.ReadValue<float>() ? true : false;
    }

    public void pressStart(InputAction.CallbackContext ctx)
    {
        MainMenu.instance.togglePause();
        startButton = 1 == ctx.ReadValue<float>() ? true : false;
        if ( startButton == true ) {
            
        }
    }

        public void pressNorth(InputAction.CallbackContext ctx)
    {
        northButton = 1 == ctx.ReadValue<float>() ? true : false;
    }

    public void pressSouth(InputAction.CallbackContext ctx)
    {
        southButton = 1 == ctx.ReadValue<float>() ? true : false;
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        fakeCoin = transform.Find("FakeCoin").gameObject;
        koStatus = transform.Find("KOStatus").gameObject;
        dashStatus = transform.Find("DashStatus").gameObject;
        recoverStatus = transform.Find("RecoverStatus").gameObject;
        currentPlayerSpeed = speed;
        playerColor = transform.Find("MainColor").gameObject.GetComponent<SpriteRenderer>();


        LobbyScript.instance.initPlayer(this);
    }

    public int getScore()
    {
        return score;
    }

    public int getNumber()
    {
        return playerNumber;
    }

    public Rigidbody2D getRigidbody()
    {
        return rb;
    }

    public string getPlayerHealth()
    {
        return playerHealth;
    }

    public bool isOk()
    {
        return getPlayerHealth() == "ok";
    }

    public bool isRecovering()
    {
        return getPlayerHealth() == "recovering";
    }

    public bool isKO()
    {
        return getPlayerHealth() == "ko";
    }

    public bool isDashAvailable()
    {
        if (isDashingVal)
        {
            return false;
        }

        // Disable dash when holding coin
        if (isHoldingCoin())
        {
            return false;
        }

        if (dashSleepTimer < dashSleepDuration)
        {
            return false;
        }

        return true;
    }

    public bool isTracked()
    {
        if (isKO())
        {
            return false;
        }

        if (isRecovering())
        {
            return false;
        }

        return isTrackedVal;
    }

    public bool isHoldingCoin()
    {
        return isHoldingCoinVal;
    }

    public bool isHoldingBonus()
    {
        return isHoldingBonusVal;
    }


    public bool isUsingBonus()
    {
        return isUsingBonusVal;
    }

    public Bonus getBonus()
    {
        return bonus;
    }

    public Bonus getStashedBonus()
    {
        return stashedBonus;
    }

    public void initState() {
        setIsHoldingBonus(false);
        setIsHoldingCoin(false);
        setOK();
        resetPlayerSpeed();
    }

    public void setBonus(Bonus newBonus)
    {
        bonus = newBonus;
    }

    public void setStashedBonus(Bonus newBonus)
    {
        stashedBonus = newBonus;
    }

    public void loadStashedBonus() {
        if ( getStashedBonus() != null) {
            setBonus(getStashedBonus());
        }

        stashedBonus = default(Bonus);
    }

    public void setIsHoldingBonus(bool isHolding)
    {

        isHoldingBonusVal = isHolding;
    }

    public void setNumber(int number)
    {
        playerNumber = number;
    }

    public Color getColor() {
        return playerColor.color;
    }

    public void setColor(Color color)
    {
        playerColor.color = color;
    }

    bool isDashPressed()
    {
        return dashButton == true;
    }

    bool isBonusPressed()
    {
        return bonusButton == true;
    }

    bool isStartPressed()
    {
        return startButton == true;
    }

    bool isNorthPressed()
    {
        return northButton == true;
    }

    bool isSouthPressed()
    {
        return southButton == true;
    }

    bool isDashing()
    {
        return isDashingVal;
    }

    float getHorizontalAxe()
    {
        if (rightButton)
        {
            return 1f;
        }

        if (leftButton)
        {
            return -1f;
        }

        return 0f;
    }

    float getVerticalAxe()
    {
        if (upButton)
        {
            return 1f;
        }

        if (downButton)
        {
            return -1f;
        }

        return 0f;
    }

    public void setTracked(bool isTracked)
    {
        isTrackedVal = isTracked;
    }

    public bool setKO()
    {
        if (!isKO())
        {
            playerHealth = "ko";
            koTimer = 0;
            rb.velocity = Vector3.zero;
            koStatus.SetActive(true);

            return true;
        }

        return false;
    }

    public void setOK()
    {
        koTimer = 0;
        playerHealth = "ok";
        koStatus.SetActive(false);
        recoverStatus.SetActive(false);
    }

    public void setRecovering()
    {
        koTimer = 0;
        playerHealth = "recovering";
        koStatus.SetActive(false);
        recoverStatus.SetActive(true);
    }

    public void setIsHoldingCoin(bool isHoldingCoin)
    {
        fakeCoin.SetActive(isHoldingCoin);
        isHoldingCoinVal = isHoldingCoin;
    }

    public float getNormalSpeed()
    {
        return speed;
    }

    public void setPlayerSpeed(float newSpeed)
    {
        currentPlayerSpeed = newSpeed;
    }

    public void resetPlayerSpeed()
    {
        currentPlayerSpeed = speed;
    }

    public void updatePlayerStatus()
    {
        koTimer += Time.deltaTime;
        dashTimer += Time.deltaTime;

        if (isKO())
        {
            // Disable dash so the user can't dash right after ko
            dashSleepTimer = 0;

            if (koTimer > koDuration)
            {
                setRecovering();
            }

            return;
        }
        else if (isRecovering())
        {
            if (koTimer > koDuration)
            {
                setOK();
            }
        }
    }

    public void updateDashStatus()
    {

        // Dashing time expiration
        if (isDashingVal && dashTimer > dashDuration)
        {
            isDashingVal = false;
            dashSleepTimer = 0;

            return;
        }

        // New dash
        if (!isDashingVal && isDashPressed() && isDashAvailable())
        {
            isDashingVal = true;
            dashTimer = 0f;

            return;
        }
    }

    public void updateBonusStatus()
    {
        bonusTimer += Time.deltaTime;

        if (!isUsingBonus())
        {
            if (isBonusPressed() && isHoldingBonus())
            {
                bonusTimer = 0;
                isUsingBonusVal = true;
                bonus.triggerBonus();
            }

            return;
        }

        if (bonusTimer > bonus.getDuration() || isKO())
        {
            isUsingBonusVal = false;
            if ( bonus != null ) {
                bonus.StopBonus();
            }

            if ( getStashedBonus() != null ) {
                setBonus(getStashedBonus());
            }
        }
    }

    public void resetStartPos()
    {
        if (isHoldingCoin())
        {
            setIsHoldingCoin(false);
            Main.instance.GenerateCoin();
        }
    }

    public void increaseScore()
    {
        score++;
    }

    public void decreaseScore()
    {
        score--;
        if (score < 0)
        {
            score = 0;
        }
    }

    public void resetScore()
    {
        score = 0;
    }

    void FixedUpdate()
    {
        updatePlayerStatus();
        updateDashStatus();
        updateBonusStatus();
        if (isKO())
        {
            return;
        }

        if (isDashing())
        {
            currentSpeed = dashSpeed;

        }
        else
        {
            currentSpeed = currentPlayerSpeed;
            dashSleepTimer += Time.deltaTime;
        }

        rb.velocity = Vector3.ClampMagnitude(new Vector3(getHorizontalAxe(), getVerticalAxe(), 0) * currentSpeed, currentSpeed) * Time.deltaTime;

        dashStatus.SetActive(isDashAvailable());
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (isHoldingCoin())
        {
            if (collider.tag == "Player")
            {
                PlayerMovements playerScript = collider.gameObject.GetComponent<PlayerMovements>();
                if (playerScript.isDashingVal)
                {
                    playerScript.setIsHoldingCoin(true);
                    setIsHoldingCoin(false);
                    setKO();
                }
            }
        }
    }
}
