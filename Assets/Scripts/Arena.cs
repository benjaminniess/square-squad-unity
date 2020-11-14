using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena
{
    private string arenaKey;

    private string arenaName;

    public Arena(string initArenaKey, string initArenaName)
    {
        arenaKey = initArenaKey;
        arenaName = initArenaName;
    }

    public string GetName()
    {
        return arenaName;
    }

    public string GetSceneName()
    {
        return arenaKey;
    }

    public string GetPreviewImage()
    {
        return arenaKey;
    }
}
