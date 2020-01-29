using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody2D playerRb;
    private GameObject heldObstacle = null;

    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed; 
    [SerializeField] private float jumpForce; 

    public float maxHealth = 150f;
    public float currentHealth;
    public float speed;
    //Invincibilité
    private bool canTakeDamages = true;
    private bool animIsRunning = false;
    //Movement changes
    public bool isOnTheGround;
    public bool isInWater;
    public bool isOnLadder;

    void Start()
    {
        isOnTheGround = false;
        isInWater = false;
        isOnLadder = false;
        currentHealth = maxHealth; // avoir la vie au max quand le niveau commence
    }

    public void TakeDamage(int damage) // les dégats qu'il prends si a 0 hp le niveau restart
    {
        if (canTakeDamages == true)
        {
            currentHealth -= damage;
            HealthBarScript.health -= damage;
            canTakeDamages = false;
            StartCoroutine(invulnerableAction());
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            Debug.Log("Invincible");
        }
    }

    public void move(Vector2 moveDirection)
    {
        if (moveDirection.x > 0)
        {
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 0f, this.transform.eulerAngles.z);
        }
        else if (moveDirection.x < 0)
        {
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 180f, this.transform.eulerAngles.z);
        }

        playerRb.transform.Translate(Vector3.right * moveSpeed);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (heldObstacle == null)
        {
            if (collision.gameObject.GetComponent<DynamicObstacles>())
            {
                heldObstacle = collision.gameObject;
                heldObstacle.GetComponent<DynamicObstacles>().PickUp();
            }
        }
    }

    public void LaunchHeldObstacle()
    {
        if (heldObstacle != null)
        {
            heldObstacle.GetComponent<DynamicObstacles>().LaunchObject();
            heldObstacle = null;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        /*if (collision.CompareTag("Water"))
        {

            isInWater = true;
            isOnTheGround = false;
            GetComponent<Rigidbody2D>().gravityScale = 2.5F;
            moveSpeed = 0.1f;
            if (Input.GetKeyDown(KeyCode.Z))
            {
                playerRb.GetComponent<Rigidbody2D>().velocity = new Vector3(0, speed, 0);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                playerRb.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -speed, 0);
            }
            playerRb.transform.Translate(Vector3.right * speed);
        }*/
    }   

    void OnTriggerExit2D()
    {/*
        isInWater = false;
        moveSpeed = 0.2f;
        GetComponent<Rigidbody2D>().gravityScale = 5F;
        playerRb.transform.Translate(Vector2.right * moveSpeed);*/
    }
    
    public void jump(float yMoveValue)
    {
        if (isOnLadder)
        {
            playerRb.transform.Translate(Vector3.up * yMoveValue * moveSpeed);
        }
        else if (isOnTheGround && yMoveValue > 0)
        {
            playerRb.AddForce(Vector2.up * jumpForce);
            isOnTheGround = false;
        }
    }



    IEnumerator invulnerableAction()
    {
        StartCoroutine(invulnerableTime());
        yield return new WaitForSeconds(1f);
        while (animIsRunning == true)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.05f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.15f);
        }
        canTakeDamages = true;
    }

    IEnumerator invulnerableTime()
    {
        animIsRunning = true;
        yield return new WaitForSeconds(2f);
        animIsRunning = false;
    }


}
