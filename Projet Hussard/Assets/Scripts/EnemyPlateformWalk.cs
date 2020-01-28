using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class EnemyPlateformWalk : MonoBehaviour 
{
    
    public LayerMask enemyMask;
    public float speed = 1;
    Rigidbody2D myBody;
    Transform myTrans;
    public Transform player;
    
 
    float myWidth, myHeight;
    public GameObject shootGO;
    public GameObject follow;
    public GameObject patrol;
    public bool aggro;

    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        myWidth = mySprite.bounds.extents.x;
        myHeight = mySprite.bounds.extents.y;
        patrol.GetComponent<EnemyPlateformWalk>().enabled = true;
        shootGO.GetComponent<EnemyShot>().enabled = false;
        follow.GetComponent<EnemyShotDistance>().enabled = false;
    }

    void FixedUpdate()
    {
        //NOTE: This script makes use of the .toVector2() extension method.
       

        //Use this position to cast the isGrounded/isBlocked lines from
        Vector2 lineCastPos = myTrans.position.toVector2() - myTrans.right.toVector2() * myWidth + -Vector2.up * myHeight;
        

        //Check to see if there's ground in front of us before moving forward
        Debug.DrawLine(lineCastPos, lineCastPos + -Vector2.up);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + -Vector2.up, enemyMask);

        //Check to see if there's a wall in front of us before moving forward
        Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2() * 0.1f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() * 0.1f, enemyMask);
        
        
        //If theres no ground, turn around. Or if I hit a wall, turn around
        if (!isGrounded || isBlocked)
        { 
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += -180;
            myTrans.eulerAngles = currRot;
        }

        //Always move forward
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.name == "Player")
        {

            
            aggro = true;
            patrol.GetComponent<EnemyPlateformWalk>().enabled = false;
            shootGO.GetComponent<EnemyShot>().enabled = true;
            follow.GetComponent<EnemyShotDistance>().enabled = true;
            
            
            
           
        }
        else if (collision.CompareTag("Bullet"))
        {
            Debug.Log("bullet");
            aggro = true;
            patrol.GetComponent<EnemyPlateformWalk>().enabled = false;
            shootGO.GetComponent<EnemyShot>().enabled = true;
            follow.GetComponent<EnemyShotDistance>().enabled = true;
        }
    }

   
}