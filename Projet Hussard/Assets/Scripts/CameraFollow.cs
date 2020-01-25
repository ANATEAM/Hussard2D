using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;
    //private Vector3 offset;

    [SerializeField] private Transform MinXLimit;
    [SerializeField] private Transform MaxXLimit;

    // Start is called before the first frame update
    void Start()
    {
        //offset = new Vector3(0, this.transform.position.y - target.transform.position.y, this.transform.position.z); //Pour le mouvements et la possition de la caméra
        //this.transform.position = target.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {

        //this.transform.position = target.transform.position + offset;

        //Debug.Log("posX: " + target.position.x);
        if (target.position.x < MinXLimit.position.x)
        {
            transform.position = new Vector3(MinXLimit.position.x, transform.position.y, transform.position.z);
        }
        else if (target.position.x > MaxXLimit.position.x)
        {
            transform.position = new Vector3(MaxXLimit.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
