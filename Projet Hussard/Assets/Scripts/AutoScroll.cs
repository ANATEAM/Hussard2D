using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private Transform target;
    public float timeScroll = 30f;
    public bool isOnScroll;

    private void Start()
    {
        offset = transform.position - target.transform.position;
    }

    private void Update()
    {
        transform.position = target.transform.position + offset;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isOnScroll)
            {

            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isOnScroll)
            {

            }
        }
    }

}
