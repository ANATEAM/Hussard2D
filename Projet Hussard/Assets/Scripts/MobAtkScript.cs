using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAtkScript : MonoBehaviour
{
    public GameObject shootGO;
    public GameObject follow;
    public GameObject patrol;
    public bool aggro;
    void Start()
    {
        patrol.GetComponent<EnemyPlateformWalk>().enabled = true;
        shootGO.GetComponent<EnemyShot>().enabled = false;
        follow.GetComponent<EnemyShotDistance>().enabled = false;
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

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Player")
        {
            shootGO.GetComponent<EnemyShot>().enabled = false;
            follow.GetComponent<EnemyShotDistance>().enabled = true;
            patrol.GetComponent<EnemyPlateformWalk>().enabled = true;
        }
    }
}
