using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour
{

	public float speed = 5;



	void OnTriggerStay2D(Collider2D ladder)
	{
		if (ladder.gameObject.CompareTag("Player"))
		{
			if (Input.GetKey(KeyCode.Z))
			{
				ladder.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
			}

			else if (Input.GetKey(KeyCode.S))
			{
				ladder.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
			}
            else if (Input.GetKey(KeyCode.Q))
            {
                ladder.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
            }

            else if (Input.GetKey(KeyCode.D))
            {
                ladder.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            }
            else
			{
				ladder.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

			}
		}



	}
}
