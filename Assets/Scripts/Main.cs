using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public static Main instance;

    public GameObject Coin;
    public GameObject Player;

    private int PlayerCount = 0;

    private GameObject[] playersScores;
    private GameObject[] PlayersObjects;

    public GameObject[] BonusTypes;

    private void Awake(){
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
        GenerateCoin();
        GenerateBonus();
        GenerateBonus();
        GeneratePlayers();
    }

    // Update is called once per frame
    void Update() {
        UpdateScores();
    }

    public void initPlayer(PlayerMovements playerScript) {
        PlayerCount ++;

        GameObject spawnPosition =  GameObject.Find("SpawnPositionForPlayer" + PlayerCount);
        Rigidbody2D rb = playerScript.getRigidbody();
        rb.MovePosition(spawnPosition.transform.position);

        playersScores[PlayerCount-1].SetActive(true);

        PlayersObjects = GameObject.FindGameObjectsWithTag("Player");
    }

    public void GeneratePlayers() {
        PlayersObjects = new GameObject[4];
        playersScores = new GameObject[4];
        for ( int i = 0; i < 4; i++) {
            playersScores[i] = GameObject.Find("ScorePlayer" + (i+1));
            playersScores[i].SetActive(false);
        }
    }

    public void GenerateCoin() {
        float spawnY = Random.Range(-20,20);
        float spawnX = Random.Range(-32, 32);
        
        Instantiate(Coin, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
    }

    public void GenerateBonus() {
        float spawnY = Random.Range(-20,20);
        float spawnX = Random.Range(-32, 32);

        int BonusKey = Random.Range(0, (BonusTypes.Length));

        Instantiate(BonusTypes[BonusKey], new Vector3(spawnX, spawnY, 0), Quaternion.identity);
    }

    public GameObject[] getPlayers() {
        return PlayersObjects;
    }

    public void UpdateScores() {
        if ( PlayersObjects == null || PlayersObjects.Length == 0 ) {
            return;
        }

        int i = 0;
        foreach ( GameObject Player in PlayersObjects ) {
            if ( Player == null ) {
                continue;
            }
            PlayerMovements playerScript = Player.GetComponent<PlayerMovements>();
            playersScores[i].GetComponent<TMPro.TextMeshProUGUI>().SetText(playerScript.getScore().ToString());
            i++;
        }   
    }
}
