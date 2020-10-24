using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public static Main instance;

    public GameObject Coin;
    public GameObject Player;

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

    public void GeneratePlayers() {
        playersScores = new GameObject[4];
        for ( int i = 0; i < 4; i++) {
            playersScores[i] = GameObject.Find("ScorePlayer" + (i+1));
            playersScores[i].SetActive(false);
        }

        for ( int i = 1; i <= 2; i++) {
            GameObject spawnPosition =  GameObject.Find("SpawnPositionForPlayer" + i);
            GameObject PlayerObject = Instantiate(Player, spawnPosition.transform.position, Quaternion.identity);
            PlayerMovements playerScript = PlayerObject.GetComponent<PlayerMovements>();
            playersScores[i-1].SetActive(true);

            if ( i == 1 ) {
                playerScript.upTouch = "z";
                playerScript.leftTouch = "q";
                playerScript.rightTouch = "d";
                playerScript.downTouch = "s";
                playerScript.dashTouch = "g";
                playerScript.bonusTouch = "f";
            } else if ( i == 2 ) {
                playerScript.upTouch = "up";
                playerScript.leftTouch = "left";
                playerScript.rightTouch = "right";
                playerScript.downTouch = "down";
                playerScript.dashTouch = "n";
                playerScript.bonusTouch = "b";
            } else if ( i == 3 ) {
                playerScript.upTouch = "u";
                playerScript.leftTouch = "h";
                playerScript.rightTouch = "k";
                playerScript.downTouch = "j";
                playerScript.dashTouch = "l";
                playerScript.bonusTouch = "m";
            } else if ( i == 4 ) {
                playerScript.upTouch = "w";
                playerScript.leftTouch = "x";
                playerScript.rightTouch = "c";
                playerScript.downTouch = "v";
                playerScript.dashTouch = "p";
                playerScript.bonusTouch = "m";
            }
        }

        PlayersObjects = GameObject.FindGameObjectsWithTag("Player");
        
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
        int i = 0;
        foreach ( GameObject Player in PlayersObjects ) {
            PlayerMovements playerScript = Player.GetComponent<PlayerMovements>();
            playersScores[i].GetComponent<TMPro.TextMeshProUGUI>().SetText(playerScript.getScore().ToString());
            i++;
        }   
    }
}
