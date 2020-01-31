using UnityEngine;
using System.Collections;

public class Ladder1 : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    public Rigidbody2D playerRb;
    

    //Quand le joueur passe sur l'échelle
    //Entre dans le trigger de l'échelle
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerManager.isOnLadder = true;
            playerRb.gravityScale = 0f;
        }
    }

    //Quand le joueur sort de l'échelle
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Hors ladder");
        playerManager.isOnLadder = false;
        playerManager.isOnTheGround = false;
        playerRb.gravityScale = 5f;
    }
}
