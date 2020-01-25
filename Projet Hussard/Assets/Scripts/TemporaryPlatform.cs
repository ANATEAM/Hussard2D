using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryPlatform : MonoBehaviour
{
    [SerializeField] private GameObject temporaryPlatform;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public IEnumerator OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == ("Player"))
        {
            yield return new WaitForSeconds(1f);
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
