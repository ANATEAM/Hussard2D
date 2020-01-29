using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPInside : MonoBehaviour
{
    public Animator transitionI;
    public float transitionTime = 1f;
    [SerializeField] private GameObject objectToTP;
    [SerializeField] private Transform placeTP;
    public bool needInput;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && needInput == false)
        {
            StartCoroutine(InsideTP());
        }
        else if (collision.CompareTag("Player") && needInput == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(InsideTP());
            }
        }
    }
    IEnumerator InsideTP()
    {
        //Play animation
        transitionI.SetTrigger("StartI");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //TP Player
        objectToTP.transform.position = placeTP.position;


    }
}
