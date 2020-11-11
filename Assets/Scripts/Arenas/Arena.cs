using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public static Arena instance;

    void Awake()
    {
        if (instance != null)
        {
            GameObject.Destroy (instance);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
    }
}
