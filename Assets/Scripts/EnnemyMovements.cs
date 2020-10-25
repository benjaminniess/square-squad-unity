using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyMovements : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        GameObject Player = FindClosestPlayer();
        if (Player)
        {
            agent.SetDestination(new Vector3(Player.transform.position.x, Player.transform.position.y, agent.transform.position.z));
            transform.LookAt(Player.transform.position);
            //transform.Rotate(new Vector3(0, -90, -90), Space.Self);
            //transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        } else {
            agent.SetDestination(agent.transform.position);
        }
        

    }

    public GameObject FindClosestPlayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            PlayerMovements playerScript = go.gameObject.GetComponent<PlayerMovements>();
            if (!playerScript.isTracked())
            {
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerMovements playerScript = collider.gameObject.GetComponent<PlayerMovements>();

            if (!playerScript.isRecovering() && playerScript.setKO())
            {
                playerScript.decreaseScore();
            }
        }
    }
}
