using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    // Vida actual
    float health;

    //Barra de vida
    public Image healthBar;

    //Máxima vida
    const float MAX_HEALTH = 100;

    float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarFiller();
        lerpSpeed = 3f * Time.deltaTime;
        ColorChanger();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / MAX_HEALTH, lerpSpeed);
    }

    void ColorChanger()
    {

        Color healthColor = Color.Lerp(Color.red, Color.green, (health / MAX_HEALTH));
        healthBar.color = healthColor;
    }

    public void Damage(float damagePoints)
    {
        if (health > 0) health -= damagePoints;
    }

    public void Heal(float healingPoints)
    {
        if (health < MAX_HEALTH) health += healingPoints;
    }
}
