using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class DeathZone : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        
       if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

       
        
    }
}