using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScript : MonoBehaviour
{
    public static LobbyScript instance;

    public GameObject Player;

    private int PlayerCount = 0;

    private GameObject[] PlayersObjects;
    private GameObject[] playersScores;

    private void Awake()
    {
        if(instance == null){
             DontDestroyOnLoad(gameObject);
             instance = this;
         }
         else{
             if(instance != this){
                 Destroy (gameObject);
             }
         }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void reset() {
        ResetPlayers();
    }

    public void initPlayer(PlayerMovements playerScript)
    {
        Scene scene = SceneManager.GetActiveScene();
        if ( scene.name != "Lobby" ) {
            Destroy(playerScript.gameObject);
            return;
        }

        PlayerCount++;

        GameObject spawnPosition = GameObject.Find("SpawnPositionForPlayer" + PlayerCount);
        Rigidbody2D rb = playerScript.getRigidbody();
        rb.transform.position = spawnPosition.transform.position;
        playerScript.name = "player_" + PlayerCount;
        playerScript.setNumber(PlayerCount);
        if ( PlayerCount == 1 ) {
            playerScript.setColor(new Color(146f/255f, 100f/255f, 244f/255f));
        } else if ( PlayerCount == 2 ) {
            playerScript.setColor(new Color(242f/255f, 118f/255f, 46f/255f));
        } else if ( PlayerCount == 3 ) {
            playerScript.setColor(new Color(171f/255f, 191f/255f, 21f/255f));
        } else {
            playerScript.setColor(new Color(88f/255f, 109f/255f, 245f/255f));
        }
        DontDestroyOnLoad(playerScript);

        int ArraySize = PlayersObjects == null ? 1 : PlayersObjects.Length + 1;
        GameObject[] save = PlayersObjects;
        PlayersObjects = new GameObject[ArraySize];
        int i = 0;

        if ( save != null ) {
            foreach (GameObject Player in save)
            {
                PlayersObjects[i] = Player;
                i++;
            }
        }
        
        PlayersObjects[i] = playerScript.gameObject;
    }

    public void ResetPlayers() {
        int playerReCount = 1;
        if ( PlayersObjects == null ) {
            return;
        }
        foreach (GameObject Player in PlayersObjects)
        {
            Player.SetActive(true);
            PlayerMovements playerScript = Player.GetComponent<PlayerMovements>();
            playerScript.setNumber(playerReCount);
            GameObject spawnPosition = GameObject.Find("SpawnPositionForPlayer" + playerReCount);
            Rigidbody2D rb = playerScript.getRigidbody();
            rb.transform.position = spawnPosition.transform.position;
            playerReCount ++;
        }
    }

    public void hidePlayers() {
        foreach (GameObject Player in getPlayers())
        {
            Player.SetActive(false);
        }
    }

    public void showPlayers() {
        foreach (GameObject Player in getPlayers())
        {
            Player.SetActive(true);
        }
    }

    public GameObject[] getPlayers()
    {
        return PlayersObjects;
    }
}
