using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] GameObject bulletEnemy;
    public Transform mobShootPoint;
    float shotRate;
    float nextShot;
    
    void Start()
    {
        shotRate = 0.2f; // 5 balles par seconde
        nextShot = Time.time;

    }


    void Update()
    {
         TimeToFire(); 
    }

    void TimeToFire()// verifie si la sec est passée pour retirer
    {
        if (Time.time > nextShot)
        {
            Instantiate(bulletEnemy, mobShootPoint.position, transform.rotation);
            nextShot = Time.time + shotRate;
        }
    }
}
