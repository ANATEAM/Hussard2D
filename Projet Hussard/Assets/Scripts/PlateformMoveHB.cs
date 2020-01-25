using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMoveHB : MonoBehaviour
{
    public Transform haut, bas;
    public Transform startPosition;
    public float speed;
    public float wait;
    Vector3 nextPosition;

    void Start()
    {
        nextPosition = startPosition.position;
    }

    // Update is called once per frame
    void Update() // si la plateforme est en haut, elle descend, et inversement
    {
        StartCoroutine(Wait());
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }
    private void OnDrawGizmos() // ligne d'itineraire
    {
        Gizmos.DrawLine(haut.position, bas.position);
    }

    public IEnumerator Wait()
    {
        if (transform.position == haut.position)
        {
            yield return new WaitForSeconds(wait);
            nextPosition = bas.position;
        }
        else if (transform.position == bas.position)
        {
            yield return new WaitForSeconds(wait);
            StartCoroutine(Wait());
            nextPosition = haut.position;
        }
    }
}