using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{

    

    public IEnumerator Shake(float duree, float force)
    {
        Vector3 originalPosition = transform.position;
        float elapsed = 0.0f;
        
        while (elapsed < duree)
        {
            float x = Random.Range(-1f, 1f) * force;
            float y = Random.Range(-1f, 1f) * force;

            transform.position += new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            yield return 0;
        }
       // transform.position = originalPosition ;
    }


}