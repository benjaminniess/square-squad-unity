using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScript : MonoBehaviour
{
    public static LobbyScript instance;

    private GameObject[] playersScores;

    private Dictionary<int, GameObject> Players;

    private PlayerController controller;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad (gameObject);
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy (gameObject);
            }
        }

        Players = new Dictionary<int, GameObject>();

        controller = new PlayerController();
        controller.Gameplay.SOUTH.performed += ctx => BackAction();
    }

    void OnEnable()
    {
        controller.Enable();
    }

    void BackAction()
    {
        if (getPlayers().Count < 1)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Play()
    {
        if (getPlayers().Count > 0)
        {
            controller.Disable();
            Time.timeScale = 1;
            SceneManager.LoadScene("Arena2");
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
                playerLobbyUIScript.showReadyButton(false);
                playerLobbyUIScript.showReadyText(true);
                playerScript.setReady(true);
            }
            else
            {
                bool allReady = true;
                foreach (KeyValuePair<int, GameObject> PlayerReady in Players)
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
                    Play();
                }
            }
        }
        else if ("South" == Button)
        {
            if (playerScript.isReady())
            {
                playerLobbyUIScript.showReadyButton(true);
                playerLobbyUIScript.showBack(true);
                playerLobbyUIScript.showReadyText(false);
                playerScript.setReady(false);
            }
            else
            {
                playerLobbyUIScript.showPressToJoin(true);
                playerLobbyUIScript.showReadyButton(false);
                playerLobbyUIScript.showBack(false);
                playerLobbyUIScript.showReadyText(false);

                foreach (KeyValuePair<int, GameObject> PlayerToD in Players)
                {
                    PlayerMovements playerToDScript =
                        PlayerToD.Value.GetComponent<PlayerMovements>();
                    if (playerToDScript.getNumber() == playerScript.getNumber())
                    {
                    }
                }

                Players.Remove(playerScript.getNumber());
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

        int PlayerCount = Players.Count + 1;

        GameObject playerLobbyUI =
            GameObject.Find("PlayerLobbyUI" + PlayerCount);
        PlayerLobbyUI playerLobbyUIScript =
            playerLobbyUI.GetComponent<PlayerLobbyUI>();

        playerLobbyUIScript.showPressToJoin(false);
        playerLobbyUIScript.showBack(true);
        playerLobbyUIScript.showReadyButton(true);

        DontDestroyOnLoad (playerScript);

        Players.Add(PlayerCount, playerScript.gameObject);

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
        foreach (KeyValuePair<int, GameObject> Player in Players)
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
                    .setColor(new Color(242f / 255f, 118f / 255f, 46f / 255f));
            }
            else if (playerReCount == 3)
            {
                playerScript
                    .setColor(new Color(171f / 255f, 191f / 255f, 21f / 255f));
            }
            else
            {
                playerScript
                    .setColor(new Color(88f / 255f, 109f / 255f, 245f / 255f));
            }

            NewPlayers.Add(playerReCount, playerScript.gameObject);

            playerReCount++;
        }

        Players = NewPlayers;
    }

    public void hidePlayers()
    {
        foreach (KeyValuePair<int, GameObject> Player in Players)
        {
            //Player.SetActive(false);
            Player.Value.transform.position = new Vector3(-100, -100, -100);
        }
    }

    public Dictionary<int, GameObject> getPlayers()
    {
        return Players;
    }
}
