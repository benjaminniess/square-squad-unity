using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovements : MonoBehaviour
{
    public GameObject[] Players;
    public GameObject[] Ennemies;
    private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        Ennemies = GameObject.FindGameObjectsWithTag("Ennemy");




    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject Player in Players) {
            foreach (GameObject Ennemy in Ennemies) {
                //Ennemy.transform.LookAt(Player.transform.position);
                Ennemy.transform.LookAt(Player.transform.position);
                Ennemy.transform.Rotate(new Vector3(0,-90,0), Space.Self);
                Ennemy.transform.position = Vector2.MoveTowards(Ennemy.transform.position, Player.transform.position, speed * Time.deltaTime);
                //Debug.Log(Player);
                //Player.transform.position = new Vector2(0, 1f);
                //Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation);
            }
            //Debug.Log(Player);
        }
    }
}
