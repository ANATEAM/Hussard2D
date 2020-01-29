using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    public float timeScroll = 30f;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }

}
