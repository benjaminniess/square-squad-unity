using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class Main : MonoBehaviour
{

    public static Main instance;

    public GameObject Coin;
    public GameObject Player;

    private GameObject[] playersScores;
    private GameObject[] PlayersObjects;

    private float timeRemaining = 10;
    private TextMeshProUGUI countDownText;
    private GameObject GameOverMenu;

    private Tilemap map;

    public GameObject[] BonusTypes;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        map = FindObjectOfType<Tilemap>();
        Time.timeScale = 60;
        countDownText = GameObject.Find("Countdown").GetComponent<TMPro.TextMeshProUGUI>();
        GameOverMenu = GameObject.Find("GameOverMenu");
        GameOverMenu.SetActive(false);
        GenerateCoin();
        GenerateBonus();
        GenerateBonus();
        GeneratePlayers();
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        countDownText.SetText(((int)timeRemaining).ToString());
        if ( timeRemaining <= 0 ) {
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
        }
        UpdateScores();
    }

    public void GeneratePlayers()
    {
        playersScores = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {

            playersScores[i] = GameObject.Find("InfosPlayer" + (i + 1));
            playersScores[i].SetActive(false);
        }

        PlayersObjects = LobbyScript.instance.getPlayers();
        foreach (GameObject Player in PlayersObjects)
        {
            if ( null == Player || !Player.CompareTag("Player") ) {
                continue;
            }
            PlayerMovements playerScript = Player.GetComponent<PlayerMovements>();
            playerScript.initState();
            GameObject spawnPosition = GameObject.Find("SpawnPositionForPlayer" + playerScript.getNumber());
            Rigidbody2D rb = playerScript.getRigidbody();
            playersScores[playerScript.getNumber() - 1].SetActive(true);
            playersScores[playerScript.getNumber() - 1].transform.Find("Bonus").gameObject.SetActive(false);
            rb.transform.position = spawnPosition.transform.position;
            playerScript.resetScore();
        }
    }

    public void GenerateCoin()
    {
        int spawnY = Random.Range(-20, 20);
        int spawnX = Random.Range(-32, 32);

        TileBase tile = map.GetTile(new Vector3Int(spawnX, spawnY, 0));
        if ( null != tile ) {
            GenerateCoin();
            return;
        }

        Instantiate(Coin, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
    }

    public void GenerateBonus()
    {
        int spawnY = Random.Range(-20, 20);
        int spawnX = Random.Range(-32, 32);

        TileBase tile = map.GetTile(new Vector3Int(spawnX, spawnY, 0));
        if ( null != tile ) {
            GenerateBonus();
            return;
        }

        int BonusKey = Random.Range(0, (BonusTypes.Length));

        Instantiate(BonusTypes[BonusKey], new Vector3(spawnX, spawnY, 0), Quaternion.identity);
    }

    public GameObject[] getPlayers()
    {
        return PlayersObjects;
    }

    public void setBonusForPlayer(int playerNumber, Sprite sprite) {
        playersScores[playerNumber-1].transform.Find("Bonus").gameObject.SetActive(true);
        playersScores[playerNumber-1].transform.Find("Bonus").GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void removeBonusFromPlayer(int playerNumber, Sprite sprite) {
        playersScores[playerNumber-1].transform.Find("Bonus").gameObject.SetActive(false);
    }

    public void UpdateScores()
    {
        if (PlayersObjects == null || PlayersObjects.Length == 0)
        {
            return;
        }

        int i = 0;
        foreach (GameObject Player in PlayersObjects)
        {
            if (Player == null)
            {
                continue;
            }
            PlayerMovements playerScript = Player.GetComponent<PlayerMovements>();
            playersScores[i].transform.Find("Score/ScoreText").GetComponent<TMPro.TextMeshProUGUI>().SetText(playerScript.getScore().ToString());
            playersScores[i].transform.Find("Color").GetComponent<SpriteRenderer>().color = playerScript.getColor();
            
            i++;
        }
    }
}
