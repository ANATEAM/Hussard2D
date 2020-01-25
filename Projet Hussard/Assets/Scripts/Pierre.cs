using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pierre : MonoBehaviour
{
    GameObject pierre;

    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Sol_ColliderEau")
          
        {
            Destroy(gameObject);
        }
            
    }

}
