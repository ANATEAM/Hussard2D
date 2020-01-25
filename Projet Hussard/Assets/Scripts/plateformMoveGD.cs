using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateformMoveGD : MonoBehaviour
{
    public Transform gauche, droite;
    public Transform startPosition;
    public float speed;
    Vector3 nextPosition;
    // Start is called before the first frame update
    void Start()
    {
        nextPosition = startPosition.position;
    }

    // Update is called once per frame
    void Update() //Si la platefrome est a gauche elle part a droite, et inversement
    {
        if(transform.position == gauche.position)
        {
            nextPosition = droite.position;
        }
        if(transform.position == droite.position)
        {
            nextPosition = gauche.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }
    private void OnDrawGizmos() // ligne d'itineraire
    {
        Gizmos.DrawLine(gauche.position, droite.position);
    }
}
