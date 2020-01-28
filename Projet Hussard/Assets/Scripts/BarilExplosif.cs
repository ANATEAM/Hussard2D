using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BarilExplosif : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Autodestruct");
            Explosion();
            GameObject.Destroy(this.gameObject);
        }
    }

    private void Explosion()
    {
        float explosionForce = 20f;
        float explosionRadius = 20f;

        //CircleCastAll pour détecter tous les objets dans la zone d'explosion
        RaycastHit2D[] objectsInRadius = Physics2D.CircleCastAll(transform.position, explosionRadius, Vector2.zero);
        
        //Appliquer une force dans la bonne direction à tous les objets concernés
        foreach (RaycastHit2D hit in objectsInRadius)
        {
            GameObject go = hit.collider.gameObject;

            Debug.Log(go.name + " In Radius");

            Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Debug.Log(go.name + " has a rigidbody");

                //Calcul du vecteur représentant la direction de la force
                Vector2 dir = (go.transform.position - this.transform.position).normalized;

                //Appliquer la force à l'objet
                go.GetComponent<Rigidbody2D>().AddForce((dir + Vector2.up) * explosionForce, ForceMode2D.Impulse);

            }
        }
    }
}
