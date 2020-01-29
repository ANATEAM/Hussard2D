using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public LayerMask bulletCollision;
    public float speed = 20f;
    public int damage = 20;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed; // 
        
        Destroy(gameObject, 2f); // Detruit au bout de 2 secondes
    }
    void OnBecameInvisible() //Quand la caméra ne voit plus les bullets, elles sont détruitent
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo) // les cas de collision qui auront un effet sur le jeu via les bullet
    {
        Debug.Log(hitInfo.name);
        MobsHP mobshp = hitInfo.GetComponent<MobsHP>();
        //BossHP bosshp = hitInfo.GetComponent<BossHP>();
        

        if (mobshp !=null)
        {
            mobshp.TakeDamage(damage);
            Destroy(gameObject);
        }
       /* else if (bosshp != null)
        {
            bosshp.TakeDamage(damage);
            Destroy(gameObject);
        }*/


        else if (hitInfo.CompareTag("Bullet"))
        {
            Destroy(hitInfo.gameObject);
            Destroy(gameObject);
        }

        else if (hitInfo.CompareTag("Décors"))
        {
            Destroy(gameObject);
        }

        else if ( hitInfo.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
    

}
