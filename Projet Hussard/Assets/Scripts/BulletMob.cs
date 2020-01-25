using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMob : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 5;
    public Rigidbody2D rb;
    PlayerManager target;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerManager>();
        rb.velocity = transform.right * -speed;
        Destroy(gameObject, 2f); // Detruit au bout de X secondes
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision) // enlève X hp au joueur
    {
        if (collision.CompareTag("Player"))
        {
            
            target.TakeDamage(damage);
            //HealthBarScript.health -= 5f;
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Décors"))
        {
            Destroy(gameObject);
        }
        
    }
}
