using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    [SerializeField] private int levelToLoad;
    public bool needInput;
    [SerializeField] private bool insideTP;
    [SerializeField] private GameObject objectToTP;
    [SerializeField] private GameObject placeTP;


    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && needInput == false && insideTP == false)
        {
            StartCoroutine (LoadLevel(levelToLoad));
        }
        else if (collision.CompareTag("Player") && needInput == true && insideTP == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(LoadLevel(levelToLoad));
            }
        }
        else if (collision.CompareTag("Player") && needInput == false && insideTP == true)
        {
            StartCoroutine(InsideTP());
        }
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(levelToLoad);
    }

    IEnumerator InsideTP()
    {
        //Play animation
        //transition.SetTrigger("StartI");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //TP Player
        objectToTP.transform.position = placeTP.transform.position;
    }
}
