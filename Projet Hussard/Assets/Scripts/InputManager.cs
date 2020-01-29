using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private cantMove CantMoveScript;
    [SerializeField] private DynamicObstacles dynamicObstaclesScript;
    public bool cantMove = false;
    // Update is called once per frame
    void Update()
    {
        if(cantMove == false)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                playerManager.move(new Vector2(Input.GetAxisRaw("Horizontal"), 0));
            }
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                playerManager.jump(Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetMouseButtonDown(1))
            {
                dynamicObstaclesScript.LaunchObject();
            }
            
            /*if (Input.GetKey(KeyCode.S))
            {
                playerManager.crouch();
            }*/
        }
        else if (cantMove == true)
        {
            //Déplacement auto pour certaines phases
            playerManager.playerRb.transform.Translate(Vector2.right * CantMoveScript.moveDirectionSpeed);
        }


    }
}
