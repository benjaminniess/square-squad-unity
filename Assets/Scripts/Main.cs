using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject Coin;

    // Start is called before the first frame update
    void Start()
    {
        GenerateCoin();
    }

    // Update is called once per frame
    void Update()
    {
        if ( GameObject.FindGameObjectsWithTag("Coin").Length < 1 ) {
            GenerateCoin();
        }
    }


    public void GenerateCoin() {
        float spawnY = Random.Range(-20,20);
        float spawnX = Random.Range(-32, 32);
        
        Instantiate(Coin, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
    }
}
