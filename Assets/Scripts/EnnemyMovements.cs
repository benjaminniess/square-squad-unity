using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovements : MonoBehaviour
{
    private float speed = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
    
        GameObject Player = FindClosestPlayer();
        if ( Player) {
            transform.LookAt(Player.transform.position);
            transform.Rotate(new Vector3(0,-90,-90), Space.Self);
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
        
    }

    public GameObject FindClosestPlayer() {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            PlayerMovements playerScript = go.gameObject.GetComponent<PlayerMovements>();
            if ( playerScript.isTracked == false ) {
                continue;
            }

            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    void OnTriggerEnter2D (Collider2D collider) {
        if (collider.tag == "Player" ) {
            PlayerMovements playerScript = collider.gameObject.GetComponent<PlayerMovements>();
            playerScript.resetStartPos();
         }
    }
}
