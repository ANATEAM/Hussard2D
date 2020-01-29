using UnityEngine;
using System.Collections;

public class Ladder1 : MonoBehaviour
{
    private GameObject player;

    //Quand le joueur passe sur l'échelle
    //Entre dans le trigger de l'échelle
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            player.GetComponent<PlayerManager>().isOnLadder = true;
            player.GetComponent<Rigidbody2D>().constraints = player.GetComponent<Rigidbody2D>().constraints | RigidbodyConstraints2D.FreezePositionY;
        }
    }

    //Quand le joueur sort de l'échelle
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerManager>().isOnLadder = false;
            player.GetComponent<Rigidbody2D>().constraints -= RigidbodyConstraints2D.FreezePositionY;
        }
    }
}
