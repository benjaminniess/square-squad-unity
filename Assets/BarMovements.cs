using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMovements : MonoBehaviour
{
    public bool flip = true;

    private float barStartYPos;

    // Start is called before the first frame update
    void Start()
    {
        barStartYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
       if ( flip == true ) {
           transform.Translate(Vector2.down * Time.deltaTime * 5, Space.World);
           if ( transform.position.y < ( barStartYPos - 14 ) ) {
               flip = false;
           }
       } else {
           transform.Translate(Vector2.up * Time.deltaTime * 5, Space.World);
           if ( transform.position.y >= barStartYPos ) {
               flip = true;
           }
       }
    }
}
