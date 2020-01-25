using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;

    public void OnTriggerStay2D(Collider2D collision)
    {
        
        //Debug.Log(collision.gameObject.name);
        playerManager.isOnTheGround = true;
    }
}
