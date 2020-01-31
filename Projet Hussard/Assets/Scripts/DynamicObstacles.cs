using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacles : MonoBehaviour
{
    [SerializeField] private GameObject player;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void PickUp()
    {
        
        this.gameObject.transform.SetParent(player.transform);
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.localPosition = new Vector3(0, 1, 0);
        
    }
    

    public void LaunchObject()
    { 
        this.gameObject.transform.SetParent(null);
        GetComponent<BoxCollider2D>().enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(player.transform.right* 800);
    }
}
