using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovements : MonoBehaviour
{
    //public GameObject[] Players;
    public GameObject[] Ennemies;
    private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject Ennemy in Ennemies) {
            GameObject Player = FindClosestPlayer( Ennemy );

            Ennemy.transform.LookAt(Player.transform.position);
            Ennemy.transform.Rotate(new Vector3(0,-90,-90), Space.Self);
            Ennemy.transform.position = Vector2.MoveTowards(Ennemy.transform.position, Player.transform.position, speed * Time.deltaTime);
        }
    }

    public GameObject FindClosestPlayer( GameObject Ennemy ) {
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
