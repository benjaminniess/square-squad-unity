using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Main : MonoBehaviour
{
    public static Main instance;

    public GameObject Coin;

    public GameObject Player;

    public GameObject Ennemy;

    private GameObject[] playersScores;

    private float timeRemaining = 60;

    private TextMeshProUGUI countDownText;

    private GameObject GameOverMenu;

    private GameObject PauseMenu;

    private GameObject FinalScore1;

    private GameObject FinalScore2;

    private GameObject FinalScore3;

    private GameObject FinalScore4;

    private bool gameIsPaused = false;

    private bool isFrozenVal = true;

    private GameObject StartCountdown;

    private float startCountDownTime = 4f;

    private TextMeshProUGUI startCountDownText;

    private Tilemap map;

    public GameObject[] BonusTypes;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy (gameObject);
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameManager.instance.FadeLoadingScreen());
        map = GameObject.Find("BackgroundPadding").GetComponent<Tilemap>();
        Time.timeScale = 0;

        countDownText =
            GameObject.Find("Countdown").GetComponent<TMPro.TextMeshProUGUI>();
        startCountDownText =
            GameObject
                .Find("StartCountdownTxt")
                .GetComponent<TMPro.TextMeshProUGUI>();
        StartCountdown = GameObject.Find("StartCountdown");

        SaveData gameData = GameManager.instance.GetGameData();
        int coinNumbers = gameData.GetCoinsCount();
        for (int i = 1; i <= coinNumbers; i++)
        {
            GenerateCoin();
        }

        int bonusNumbers = gameData.GetBonusCount();
        if (bonusNumbers > 0)
        {
            for (int i = 0; i <= bonusNumbers; i++)
            {
                GenerateBonus();
            }
        }

        int ennemiesNumber = gameData.GetEnnemmiesCount();
        if (ennemiesNumber > 0)
        {
            for (int i = 1; i < ennemiesNumber + 1; i++)
            {
                GenerateEnnemy (i);
            }
        }
        GeneratePlayers();

        GameOverMenu = GameObject.Find("GameOverMenu");
        PauseMenu = GameObject.Find("PauseMenu");
        FinalScore1 = GameObject.Find("FinalScorePlayer1");
        FinalScore2 = GameObject.Find("FinalScorePlayer2");
        FinalScore3 = GameObject.Find("FinalScorePlayer3");
        FinalScore4 = GameObject.Find("FinalScorePlayer4");
        GameOverMenu.SetActive(false);
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFrozen())
        {
            startCountDownTime -= Time.fixedDeltaTime;
            startCountDownText.SetText(((int) startCountDownTime).ToString());
            if (startCountDownTime < 1)
            {
                isFrozenVal = false;
                StartCountdown.SetActive(false);
                Time.timeScale = 1;
            }
        }

        gameOver();
        UpdateScores();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
        }
    }

    public void ButtonPerformed(string button)
    {
        switch (button)
        {
            case "south":
                if (Time.timeScale == 1 || Main.instance.isFrozen())
                {
                    break;
                }

                Menu();
                break;
            case "east":
                if (Time.timeScale == 1 || Main.instance.isFrozen())
                {
                    return;
                }

                if (gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Play();
                }
                break;
            case "start":
                togglePause();
                break;
            default:
                break;
        }
    }

    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void togglePause()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else if (Time.timeScale == 1)
        {
            Paused();
        }
    }

    public void Resume()
    {
        if (!gameIsPaused)
        {
            return;
        }

        if (PauseMenu == null)
        {
            return;
        }

        PauseMenu.SetActive(false);

        Time.timeScale = 1;
        gameIsPaused = false;
    }

    void Paused()
    {
        if (gameIsPaused)
        {
            return;
        }

        if (PauseMenu == null)
        {
            return;
        }

        PauseMenu.SetActive(true);

        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Menu()
    {
        GameManager.instance.hidePlayers();
        SceneManager.LoadScene("MainMenu");
    }

    public bool isFrozen()
    {
        return isFrozenVal;
    }

    public void gameOver()
    {
        timeRemaining -= Time.deltaTime;
        countDownText.SetText(((int) timeRemaining).ToString());
        if (timeRemaining <= 0)
        {
            Time.timeScale = 0;

            GameObject[] coins;
            coins = GameObject.FindGameObjectsWithTag("Coin");
            foreach (GameObject coin in coins)
            {
                Destroy (coin);
            }

            GameOverMenu.SetActive(true);
            PauseMenu.SetActive(false);
            FinalScore1.SetActive(false);
            FinalScore2.SetActive(false);
            FinalScore3.SetActive(false);
            FinalScore4.SetActive(false);

            Dictionary<PlayerMovements, int> ScoresDictionnary =
                new Dictionary<PlayerMovements, int>();

            foreach (KeyValuePair<int, GameObject>
                Player
                in
                GameManager.instance.GetPlayers()
            )
            {
                PlayerMovements playerScript =
                    Player.Value.GetComponent<PlayerMovements>();
                ScoresDictionnary.Add(playerScript, playerScript.getScore());
                GameObject pInfos =
                    GameObject.Find("InfosPlayer" + playerScript.getNumber());
                if (pInfos != null)
                {
                    pInfos.SetActive(false);
                }
            }

            int i = 1;
            foreach (KeyValuePair<PlayerMovements, int>
                playerData
                in
                ScoresDictionnary.OrderByDescending(key => key.Value)
            )
            {
                int playerScore = playerData.Value;

                if (i == 1)
                {
                    FinalScore1.SetActive(true);
                    FinalScore1
                        .transform
                        .Find("Score/ScoreText")
                        .GetComponent<TMPro.TextMeshProUGUI>()
                        .SetText(playerData.Key.getScore().ToString());
                    FinalScore1
                        .transform
                        .Find("Position/PositionText")
                        .GetComponent<TMPro.TextMeshProUGUI>()
                        .SetText("#" + i.ToString());
                    FinalScore1
                        .transform
                        .Find("Color")
                        .GetComponent<SpriteRenderer>()
                        .color = playerData.Key.getColor();
                }
                else if (i == 2)
                {
                    FinalScore2.SetActive(true);
                    FinalScore2
                        .transform
                        .Find("Score/ScoreText")
                        .GetComponent<TMPro.TextMeshProUGUI>()
                        .SetText(playerData.Key.getScore().ToString());
                    FinalScore2
                        .transform
                        .Find("Position/PositionText")
                        .GetComponent<TMPro.TextMeshProUGUI>()
                        .SetText("#" + i.ToString());
                    FinalScore2
                        .transform
                        .Find("Color")
                        .GetComponent<SpriteRenderer>()
                        .color = playerData.Key.getColor();
                }
                else if (i == 3)
                {
                    FinalScore3.SetActive(true);
                    FinalScore3
                        .transform
                        .Find("Score/ScoreText")
                        .GetComponent<TMPro.TextMeshProUGUI>()
                        .SetText(playerData.Key.getScore().ToString());
                    FinalScore3
                        .transform
                        .Find("Position/PositionText")
                        .GetComponent<TMPro.TextMeshProUGUI>()
                        .SetText("#" + i.ToString());
                    FinalScore3
                        .transform
                        .Find("Color")
                        .GetComponent<SpriteRenderer>()
                        .color = playerData.Key.getColor();
                }
                else
                {
                    FinalScore4.SetActive(true);
                    FinalScore4
                        .transform
                        .Find("Score/ScoreText")
                        .GetComponent<TMPro.TextMeshProUGUI>()
                        .SetText(playerData.Key.getScore().ToString());
                    FinalScore4
                        .transform
                        .Find("Position/PositionText")
                        .GetComponent<TMPro.TextMeshProUGUI>()
                        .SetText("#" + i.ToString());
                    FinalScore4
                        .transform
                        .Find("Color")
                        .GetComponent<SpriteRenderer>()
                        .color = playerData.Key.getColor();
                }

                i++;
            }
        }
    }

    public void GeneratePlayers()
    {
        playersScores = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            playersScores[i] = GameObject.Find("InfosPlayer" + (i + 1));
            playersScores[i].SetActive(false);
        }

        foreach (KeyValuePair<int, GameObject>
            Player
            in
            GameManager.instance.GetPlayers()
        )
        {
            if (null == Player.Value || !Player.Value.CompareTag("Player"))
            {
                continue;
            }
            PlayerMovements playerScript =
                Player.Value.GetComponent<PlayerMovements>();
            playerScript.initState();
            GameObject spawnPosition =
                GameObject
                    .Find("SpawnPositionForPlayer" + playerScript.getNumber());
            Rigidbody2D rb = playerScript.getRigidbody();
            playersScores[playerScript.getNumber() - 1].SetActive(true);
            playerScript.setMovementEnabled(true);
            playersScores[playerScript.getNumber() - 1]
                .transform
                .Find("Bonus")
                .gameObject
                .SetActive(false);
            rb.transform.position = spawnPosition.transform.position;
            playerScript.resetScore();
        }
    }

    public void GenerateCoin()
    {
        int spawnY = Random.Range(-20, 20);
        int spawnX = Random.Range(-32, 32);

        TileBase tile = map.GetTile(new Vector3Int(spawnX, spawnY, 0));
        if (null != tile)
        {
            GenerateCoin();
            return;
        }

        AddCoinAtPosition (spawnX, spawnY);
    }

    void GenerateEnnemy(int SpawnNumber = 1)
    {
        GameObject spawnSpot = GameObject.Find("EnnemySpawn" + SpawnNumber);
        GameObject ennemyGO =
            Instantiate(Ennemy,
            spawnSpot.transform.position,
            Quaternion.identity);

        ennemyGO
            .GetComponent<EnnemyMovements>()
            .SetSpeed((
            int
            )(GameManager.instance.minEnnemySpeed + ( GameManager.instance.GetGameData().GetEnnemiesSpeed() * GameManager.instance.maxEnnemySpeed)));
    }

    public void AddCoinAtPosition(int spawnX, int spawnY)
    {
        Instantiate(Coin, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
    }

    public void GenerateBonus()
    {
        int spawnY = Random.Range(-20, 20);
        int spawnX = Random.Range(-32, 32);

        TileBase tile = map.GetTile(new Vector3Int(spawnX, spawnY, 0));
        if (null != tile)
        {
            GenerateBonus();
            return;
        }

        int BonusKey = Random.Range(0, (BonusTypes.Length));

        Instantiate(BonusTypes[BonusKey],
        new Vector3(spawnX, spawnY, 0),
        Quaternion.identity);
    }

    public void setBonusForPlayer(int playerNumber, Sprite sprite)
    {
        playersScores[playerNumber - 1]
            .transform
            .Find("Bonus")
            .gameObject
            .SetActive(true);
        playersScores[playerNumber - 1]
            .transform
            .Find("Bonus")
            .GetComponent<SpriteRenderer>()
            .sprite = sprite;
    }

    public void removeBonusFromPlayer(int playerNumber, Sprite sprite)
    {
        playersScores[playerNumber - 1]
            .transform
            .Find("Bonus")
            .gameObject
            .SetActive(false);
    }

    public void UpdateScores()
    {
        int i = 0;
        foreach (KeyValuePair<int, GameObject>
            Player
            in
            GameManager.instance.GetPlayers()
        )
        {
            PlayerMovements playerScript =
                Player.Value.GetComponent<PlayerMovements>();
            playersScores[i]
                .transform
                .Find("Score/ScoreText")
                .GetComponent<TMPro.TextMeshProUGUI>()
                .SetText(playerScript.getScore().ToString());
            playersScores[i]
                .transform
                .Find("Color")
                .GetComponent<SpriteRenderer>()
                .color = playerScript.getColor();

            i++;
        }
    }
}
