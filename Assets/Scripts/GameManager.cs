using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private PlayerController controller;

    private Dictionary<int, GameObject> players;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;

        controller = new PlayerController();
        players = new Dictionary<int, GameObject>();
    }

    public PlayerController GetController()
    {
        return controller;
    }

    public Dictionary<int, GameObject> GetPlayers()
    {
        return players;
    }

    public void SetPlayers(Dictionary<int, GameObject> newPlayers)
    {
        players = newPlayers;
    }

    public void hidePlayers()
    {
        foreach (KeyValuePair<int, GameObject> Player in GetPlayers())
        {
            Player.Value.transform.position = new Vector3(-100, -100, -100);
        }
    }
}
