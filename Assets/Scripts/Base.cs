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

    void OnTriggerEnter2D (Collider2D collider) {
        if (collider.tag == "Player" ) {
            Debug.Log(collider.transform.position);
            Debug.Log(transform.position);
            PlayerMovements playerScript = collider.gameObject.GetComponent<PlayerMovements>();
            playerScript.isTracked = false;
         }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Player" ) {
            PlayerMovements playerScript = collider.gameObject.GetComponent<PlayerMovements>();
            playerScript.isTracked = true;
         }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        
    }
}