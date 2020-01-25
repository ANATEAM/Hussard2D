
using UnityEngine;
using UnityEngine.SceneManagement;

public class MobsDamages : MonoBehaviour
{
    public int damage;
    PlayerManager target;
   

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision) //les dégats que font les mobs et la barre de hp qui diminue en fonction des dégats
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Touché!");
            target.TakeDamage(damage);
            HealthBarScript.health -= damage;

            if (target.currentHealth == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}
