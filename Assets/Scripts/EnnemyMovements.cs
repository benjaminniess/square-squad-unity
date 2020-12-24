﻿using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyMovements : MonoBehaviour
{
    public float nextWaypointDistance = 3f;

    private int currentWaypoint = 0;

    private Path path;

    public GameObject radar;

    private Rigidbody2D rb;

    private GameObject Player;

    private bool reachedPlayer = false;

    private Seeker seeker;

    Vector2 direction;
    Vector2 force;

    private int speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
    
        InvokeRepeating("UpdatePath", 0f, .1f);
    }

    void UpdatePath()
    {
        if (!seeker.IsDone())
        {
            return;
        }

        Player = FindClosestPlayer();
        if (Player)
        {
            seeker
                .StartPath(rb.position,
                Player.transform.position,
                OnPathComplete);
        }
        else
        {
            //agent.SetDestination(agent.transform.position);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 1;
        }
    }

    public void setKO()
    {
        //Debug.Log("KO");
    }

    public void SetSpeed(int speedVal)
    {
        speed = speedVal;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedPlayer = true;
            return;
        }
        else
        {
            reachedPlayer = false;
        }

        if (Player != null)
        {
            radar.SetActive(false);
            direction =
                ((Vector2) path.vectorPath[currentWaypoint] - rb.position)
                    .normalized;
            force = direction * speed * Time.deltaTime;

            float angle =
                (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90;

            transform.rotation =
                Quaternion
                    .Lerp(transform.rotation,
                    Quaternion.AngleAxis(angle, Vector3.forward),
                    Time.deltaTime * 10);
        
            rb.velocity = force;
        } else {
            radar.SetActive(true);
            rb.velocity = force / 2;
        }


        float distance =
            Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    public void kill()
    {
        Destroy (gameObject);
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
            PlayerMovements playerScript =
                go.gameObject.GetComponent<PlayerMovements>();
            if (!playerScript.isTracked())
            {
                continue;
            }

            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && curDistance < 400 )
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.tag);
        if (collider.tag == "Player")
        {
            PlayerMovements playerScript =
                collider.gameObject.GetComponent<PlayerMovements>();

            if (!playerScript.isRecovering() && playerScript.setKO())
            {
                //playerScript.decreaseScore();
            }
        }
    }
}
