using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cantMove : MonoBehaviour
{

    //Script pour definir si le joueur peux utiliser les controles.

    [SerializeField] InputManager inputManager;
    [SerializeField] public float moveDirectionSpeed;

    //Désactive les controles.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inputManager.cantMove = true;
        }

    }
    //Réactive les controles
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inputManager.cantMove = false;
        }
    }
}
