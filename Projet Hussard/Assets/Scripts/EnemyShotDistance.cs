using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotDistance : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public bool aggro;
    public Transform player;

 
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

  
    void Update()
    {

        float deltaX = player.position.x - transform.position.x;

        if (deltaX < 0 && !Mathf.Approximately(transform.rotation.y,0f))
        {

            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (deltaX > 0 && !Mathf.Approximately(transform.rotation.y, -180f))
        {
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }



       

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {

            Vector3 deplacement = player.position - transform.position;

            deplacement.y = 0;
            deplacement.z = 0;
            deplacement = deplacement.normalized;
            transform.position += deplacement * Time.deltaTime * speed;

        }


        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {

            Vector3 deplacement = player.position - transform.position;

            deplacement.y = 0;
            deplacement.z = 0;
            deplacement = deplacement.normalized;
            transform.position -= deplacement * Time.deltaTime * speed;
        }
        
    }
}
