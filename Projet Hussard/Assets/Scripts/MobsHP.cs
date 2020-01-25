using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsHP : MonoBehaviour
{
    public int health = 50;
    
    public void TakeDamage(int damage) //dégats reçus par les mobs
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public IEnumerator Autodestruct()
    {
        yield return new WaitForSeconds(0f);
        GameObject.Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bullet")
        {
            Debug.Log("Autodestruct");
            this.GetComponent<CapsuleCollider2D>().enabled = false;
            StartCoroutine(Autodestruct());

        }
    }

}
