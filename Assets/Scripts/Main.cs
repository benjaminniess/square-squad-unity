using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public static Main instance;

    public GameObject Coin;

    public GameObject[] PlayersObjects;

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
       // GenerateBonus();
        PlayersObjects = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        UpdateScores();
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
        int i = 1;
        foreach ( GameObject Player in PlayersObjects ) {
            PlayerMovements playerScript = Player.GetComponent<PlayerMovements>();
            GameObject.Find("ScorePlayer" + i).GetComponent<TMPro.TextMeshProUGUI>().SetText(playerScript.getScore().ToString());
            i++;
        }
        
    }
}
