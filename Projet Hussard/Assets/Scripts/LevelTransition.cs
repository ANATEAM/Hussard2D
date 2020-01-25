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
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && needInput == false)
        {
            StartCoroutine (LoadLevel(levelToLoad));
        }
        else if (collision.CompareTag("Player") && needInput == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(LoadLevel(levelToLoad));
            }
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
}
