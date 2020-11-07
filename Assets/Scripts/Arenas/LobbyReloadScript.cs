using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyReloadScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LobbyScript.instance.ResetPlayers(true);
    }
}
