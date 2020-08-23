using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanevasActions : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 initPosition;

    public void ResetGame() {
        rb.transform.position = initPosition;
        rb.transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = new Vector2(0,0);
        rb.angularVelocity = 0f;
    }
}
