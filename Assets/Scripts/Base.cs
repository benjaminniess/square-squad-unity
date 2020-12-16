﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerMovements playerScript =
                collider.gameObject.GetComponent<PlayerMovements>();
            playerScript.setTracked(false);
            if (playerScript.isHoldingCoin())
            {
                FindObjectOfType<AudioManager>().Play("Score");
                playerScript.increaseScore();
                playerScript.setIsHoldingCoin(false);
                Main.instance.GenerateCoin();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerMovements playerScript =
                collider.gameObject.GetComponent<PlayerMovements>();
            playerScript.setTracked(true);
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
    }
}
