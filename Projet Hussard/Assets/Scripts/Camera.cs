using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera : MonoBehaviour
{
    internal static object main;
    [SerializeField] public Transform minXLimit;
    [SerializeField] public Transform maxXLimit;
    [SerializeField] private Transform target;
    private Vector3 offset;


    private void Start()
    {
        offset = transform.position - target.transform.position;
    }

    private void Update()
    {
        transform.position = target.transform.position + offset;
        

        if (target.position.x < minXLimit.position.x)
        {
            transform.position = new Vector3(minXLimit.position.x, transform.position.y, transform.position.z);
        }

        else if (target.position.x > maxXLimit.position.x)
        {
            transform.position = new Vector3(maxXLimit.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }
    }
    

}

