using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anguille : MonoBehaviour
{
    [SerializeField] private Rigidbody2D target1;
    [SerializeField] private Rigidbody2D target2;
    public ScreenShake screenShake;

    


    public void OnDrawGizmos() // Permet de dessiner une ligne indiquant a quel GO est rattachée cette trigger
    {
        if (target1 != null)
        {
            Debug.DrawLine(this.transform.position, target1.transform.position, Color.yellow);
        }
        if (target2 != null)
        {
        Debug.DrawLine(this.transform.position, target1.transform.position, Color.yellow);
         }

    }
    


    public void OnTriggerEnter2D(Collider2D col) // Si on a un rigidbody dans la case target, et qu'il est mis en kinematic, cela le passe en dynamic 
    {
        StartCoroutine(screenShake.Shake(6f,0.2f)); // appel à la coroutine screenshake

        if (target1 != null)
        {
            target1.isKinematic = false;

            target1.WakeUp(); 
        }
        if (target2 != null)
        {
            target2.isKinematic = false;

            target2.WakeUp();
        }
        
    }
    
}
