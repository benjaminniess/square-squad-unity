using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 20);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerMovements playerScript = collider.gameObject.GetComponent<PlayerMovements>();
            if (!playerScript.isRecovering() && playerScript.setKO())
            {
                playerScript.decreaseScore();
                Destroy(gameObject);
            }
        }
    }
}
