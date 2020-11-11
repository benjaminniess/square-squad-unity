using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PlayerMovements shooter;

    private bool hasTouched = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 20);
        if (transform.position.y > 50)
        {
            Destroy (gameObject);
        }
    }

    public void setShooter(PlayerMovements shooterRef)
    {
        shooter = shooterRef;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerMovements playerScript =
                collider.gameObject.GetComponent<PlayerMovements>();
            if (!playerScript.isRecovering() && playerScript.setKO())
            {
                playerScript.decreaseScore();
            }
        }
        else if (collider.tag == "Ennemy")
        {
            if (!hasTouched)
            {
                EnnemyMovements ennemyScript =
                    collider.gameObject.GetComponent<EnnemyMovements>();
                ennemyScript.kill();
                shooter.increaseScore();
                hasTouched = true;
            }
        }

        Destroy (gameObject);
    }
}
