using UnityEngine;
using System.Collections;

public class UnCheckIsKinematicOnTriggerEnter : MonoBehaviour {

	[SerializeField] private Rigidbody2D target;

	public void OnDrawGizmos() // Permet de dessiner une ligne indiquant a quel RB est rattaché cette trigger
	{
		if (target != null)
        {
			Debug.DrawLine(this.transform.position, target.transform.position, Color.yellow);
        }
			
	}

	public void OnTriggerEnter2D(Collider2D col) // Si on as un rigidbody dans la case target, et qu'il est mis en kinematic, cela le passe en dynamic 
	{
		if (target != null)
		{
			target.isKinematic = false;
			
			target.WakeUp();
		}
	}
}