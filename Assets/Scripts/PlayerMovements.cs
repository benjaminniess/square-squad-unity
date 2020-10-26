using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovements : MonoBehaviour
{

    private float currentSpeed;
    private int score = 0;
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
    private float bonusTimer;

    private bool upButton = false;
    private bool downButton = false;
    private bool leftButton = false;
    private bool rightButton = false;
    private bool dashButton = false;
    private bool bonusButton = false;

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

    void Start()
    {
        currentPlayerSpeed = speed;
        rb = gameObject.GetComponent<Rigidbody2D>();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        playerStartPos = transform.position;
        fakeCoin = transform.Find("FakeCoin").gameObject;
        koStatus = transform.Find("KOStatus").gameObject;
        dashStatus = transform.Find("DashStatus").gameObject;
        recoverStatus = transform.Find("RecoverStatus").gameObject;
        Main.instance.initPlayer(this);
    }

    public int getScore()
    {
        return score;
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


    bool isUsingBonus()
    {
        return isUsingBonusVal;
    }

    public Bonus getBonus()
    {
        return bonus;
    }

    public void setBonus(Bonus newBonus)
    {
        bonus = newBonus;
    }

    public void setIsHoldingBonus(bool isHolding)
    {
        isHoldingBonusVal = isHolding;
    }

    bool isDashPressed()
    {
        return dashButton == true;
    }

    bool isBonusPressed()
    {
        return bonusButton == true;
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

        if (bonusTimer > bonus.getDuration() || isKO() )
        {
            isUsingBonusVal = false;
            bonus.StopBonus();
        }
    }

    public void resetStartPos()
    {
        transform.position = playerStartPos;
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
