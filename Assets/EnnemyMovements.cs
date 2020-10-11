using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovements : MonoBehaviour
{
    private float speed = 15f;

    // Update is called once per frame
    void Update()
    {
    
        GameObject Player = FindClosestPlayer();

        transform.LookAt(Player.transform.position);
        transform.Rotate(new Vector3(0,-90,-90), Space.Self);
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }

    public GameObject FindClosestPlayer() {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
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
}
