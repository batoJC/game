using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;


public class HealthBar : MonoBehaviour
{

    // Vida actual
    float health;

    //Barra de vida
    public Image healthBar;

    //Máxima vida
    const float MAX_HEALTH = 100;

    float lerpSpeed;

     AsyncOperation async;

    // Start is called before the first frame update
    void Start()
    {

        if(healthBar.name == "MeteorBar"){
            health = 0;
        }
        else{
            health = MAX_HEALTH;
        }
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

        if(this.name == "FirstPersonCharacter"){
            if(healthBar.name == "HealthBar"){
                Color healthColor = Color.Lerp(Color.red, Color.green, (health / MAX_HEALTH));
                healthBar.color = healthColor;
            }
            if(healthBar.name == "MeteorBar"){
                Color healthColor = Color.Lerp(Color.red, Color.yellow, (health / MAX_HEALTH));
                healthBar.color = healthColor;
            }

        }
        if(this.name == "REAPER_LEGACY"){
            if(healthBar.name == "BossHealthBar"){
                Color healthColor = Color.Lerp(Color.red, Color.gray, (health / MAX_HEALTH));
                healthBar.color = healthColor;
            }

        }

    }

    public void Damage(float damagePoints)
    {
        if (health > 0) {
            health -= damagePoints;
        }
        else{

            //Reiniciar la escena en caso de que al jugador se le acabe la vida
            if(this.name == "FirstPersonCharacter" && healthBar.name == "HealthBar"){

                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);

            }
            if(this.name == "REAPER_LEGACY"){
                this.GetComponent<Animator>().SetBool("die",true);
                 StartCoroutine(LoadScene());
            }

        };


    }

     IEnumerator LoadScene()
    {

        yield return new WaitForSecondsRealtime(6);

        async = Application.LoadLevelAsync("FinalScene");

        yield return async;
    }

    public void Heal(float healingPoints)
    {
        if (health <= MAX_HEALTH) health += healingPoints;
    }

    public float GetHealth(){
        return this.health;
    }
}
