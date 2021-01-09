using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScript : MonoBehaviour
{
    public static LobbyScript instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy (gameObject);
        }

        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(GameManager.instance.FadeLoadingScreen());
        ResetPlayers(true);
    }

    public void ButtonPerformed(string button)
    {
        switch (button)
        {
            case "south":
                if (GameManager.instance.GetPlayers().Count < 1)
                {
                    FindObjectOfType<AudioManager>().Play("Clack");
                    StartCoroutine(GameManager.instance.LoadScene("MainMenu"));
                }
                break;
            default:
                break;
        }
    }

    public void Play()
    {
        if (GameManager.instance.GetPlayers().Count > 0)
        {
            foreach (KeyValuePair<int, GameObject>
                Player
                in
                GameManager.instance.GetPlayers()
            )
            {
                Player.Value.transform.position = new Vector3(-40, -40, 0);
            }
            StartCoroutine(GameManager.instance.LoadScene("LevelSelect"));
        }
    }

    public void isButtonPressed(PlayerMovements playerScript, string Button)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "Lobby")
        {
            return;
        }

        GameObject playerLobbyUI =
            GameObject.Find("PlayerLobbyUI" + playerScript.getNumber());
        PlayerLobbyUI playerLobbyUIScript =
            playerLobbyUI.GetComponent<PlayerLobbyUI>();
        if ("Dash" == Button)
        {
            if (!playerScript.isReady())
            {
                FindObjectOfType<AudioManager>().Play("Click");
                playerLobbyUIScript.showReadyButton(false);
                playerLobbyUIScript.showReadyText(true);
                playerScript.setReady(true);
                playerScript.setMovementEnabled(false);
            }
            else
            {
                bool allReady = true;
                foreach (KeyValuePair<int, GameObject>
                    PlayerReady
                    in
                    GameManager.instance.GetPlayers()
                )
                {
                    PlayerMovements playerReadyScript =
                        PlayerReady.Value.GetComponent<PlayerMovements>();
                    if (!playerReadyScript.isReady())
                    {
                        allReady = false;
                    }
                }

                if (allReady == true)
                {
                    FindObjectOfType<AudioManager>().Play("DoubleClick");
                    Play();
                }
            }
        }
        else if ("South" == Button)
        {
            if (playerScript.isReady())
            {
                FindObjectOfType<AudioManager>().Play("Clack");
                playerLobbyUIScript.showReadyButton(true);
                playerLobbyUIScript.showBack(true);
                playerLobbyUIScript.showReadyText(false);
                playerScript.setReady(false);
                playerScript.setMovementEnabled(true);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Clack");
                playerLobbyUIScript.showPressToJoin(true);
                playerLobbyUIScript.showReadyButton(false);
                playerLobbyUIScript.showBack(false);
                playerLobbyUIScript.showReadyText(false);

                Dictionary<int, GameObject> players =
                    GameManager.instance.GetPlayers();
                foreach (KeyValuePair<int, GameObject> PlayerToD in players)
                {
                    PlayerMovements playerToDScript =
                        PlayerToD.Value.GetComponent<PlayerMovements>();
                    if (playerToDScript.getNumber() == playerScript.getNumber())
                    {
                    }
                }

                players.Remove(playerScript.getNumber());
                GameManager.instance.SetPlayers (players);
                Destroy(playerScript.gameObject);
                ResetPlayers();
            }
        }
    }

    public void initPlayer(PlayerMovements playerScript)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "Lobby")
        {
            Destroy(playerScript.gameObject);
            return;
        }

        Dictionary<int, GameObject> players = GameManager.instance.GetPlayers();
        int PlayerCount = players.Count + 1;

        GameObject playerLobbyUI =
            GameObject.Find("PlayerLobbyUI" + PlayerCount);
        PlayerLobbyUI playerLobbyUIScript =
            playerLobbyUI.GetComponent<PlayerLobbyUI>();

        playerLobbyUIScript.showPressToJoin(false);
        playerLobbyUIScript.showBack(true);
        playerLobbyUIScript.showReadyButton(true);

        DontDestroyOnLoad (playerScript);

        players.Add(PlayerCount, playerScript.gameObject);
        GameManager.instance.SetPlayers (players);

        ResetPlayers();
    }

    public void ResetPlayers(bool forcePosition = false)
    {
        int playerReCount = 1;

        for (int i = 1; i <= 4; i++)
        {
            GameObject playerLobbyUI = GameObject.Find("PlayerLobbyUI" + i);
            PlayerLobbyUI playerLobbyUIScript =
                playerLobbyUI.GetComponent<PlayerLobbyUI>();
            playerLobbyUIScript.reset();
        }

        Dictionary<int, GameObject> NewPlayers =
            new Dictionary<int, GameObject>();
        foreach (KeyValuePair<int, GameObject>
            Player
            in
            GameManager.instance.GetPlayers()
        )
        {
            PlayerMovements playerScript =
                Player.Value.GetComponent<PlayerMovements>();
            GameObject playerNewLobbyUI =
                GameObject.Find("PlayerLobbyUI" + playerReCount);
            PlayerLobbyUI playerNewLobbyUIScript =
                playerNewLobbyUI.GetComponent<PlayerLobbyUI>();

            playerNewLobbyUIScript.reset();
            playerNewLobbyUIScript.showPressToJoin(false);
            playerNewLobbyUIScript.showBack(true);
            playerNewLobbyUIScript.showReadyButton(!playerScript.isReady());
            playerNewLobbyUIScript.showReadyText(playerScript.isReady());

            int prevNumber = playerScript.getNumber();
            playerScript.setNumber (playerReCount);
            playerScript.setIsHoldingBonus(false);
            playerScript.setMovementEnabled(!playerScript.isReady());

            Rigidbody2D rb = playerScript.getRigidbody();

            if (prevNumber != playerReCount || forcePosition)
            {
                rb.transform.position =
                    playerNewLobbyUIScript.getSpawnPosition();
            }

            playerScript.name = "player_" + playerReCount;

            if (playerReCount == 1)
            {
                playerScript
                    .setColor(new Color(146f / 255f, 100f / 255f, 244f / 255f));
            }
            else if (playerReCount == 2)
            {
                playerScript
                    .setColor(new Color(88f / 255f, 109f / 255f, 245f / 255f));
            }
            else if (playerReCount == 3)
            {
                playerScript
                    .setColor(new Color(171f / 255f, 191f / 255f, 21f / 255f));
            }
            else
            {
                playerScript
                    .setColor(new Color(219 / 255f, 194f / 255f, 34f / 255f));
            }

            NewPlayers.Add(playerReCount, playerScript.gameObject);

            playerReCount++;
        }

        GameManager.instance.SetPlayers (NewPlayers);
    }
}
