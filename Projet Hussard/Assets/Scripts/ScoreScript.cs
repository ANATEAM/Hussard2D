using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    Text text;
    public static int coinAmount;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>(); // récup' le text du canvas pour le modifier
    }

    // Update is called once per frame
    void Update()
    {
        text.text = coinAmount.ToString(); //il augmente le nombre de pièces collectées, et garde en mémoire ce nombre entre les niveaux
    }
}
