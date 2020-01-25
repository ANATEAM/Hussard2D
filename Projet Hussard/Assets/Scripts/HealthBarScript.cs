using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarScript : MonoBehaviour
{ 
    public static float health;
    float maxHealth = 150;
    Image healthBar;

    // Start is called before the first frame update
    void Start() // récupère l'image de la barre de vie pour la controller au moyen du fillAmount en fonction des HP du joueur
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
    }
}
