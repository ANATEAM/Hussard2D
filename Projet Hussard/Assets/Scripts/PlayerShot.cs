using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update() // Quand on presse "E" on appelle la fonction shoot
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    void Shoot() //Fonction qui spawn le kunai
    {
        Debug.Log("shoot");
        Instantiate(bulletPrefab, shootPoint.position, transform.rotation);
    }
}
