using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMine : MonoBehaviour
{
    public Rigidbody2D playerRb;

    void Explode()
    {
        if (playerRb)
        {

        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            Debug.Log("Destruct");
            collision.GetComponent<PlayerManager>();
            Destroy(this.gameObject);
        }
    }
}
