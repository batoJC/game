using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    private Animator anim;
     //Maxima vida
    const float MAX_HEALTH = 100;
    // Vida actual
    float health;

     [Tooltip("Porcentaje de daño que este enemigo cause al jugador")]
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        health = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Damage(float damagePoints)
    {
        if (health > 0) {
            health -= damagePoints;
        }
        else{
            anim.SetBool("die", true);
            this.GetComponent<AudioSource>().Stop();
        }
        
    }

    private void OnTriggerEnter(Collider other)
  {
    if (other.name == "FPSController")
    {

        if(!anim.GetBool("die")){
             other.gameObject.GetComponentInChildren<HealthBar>().Damage(damage);
        }
      
      
    }
  }

  private void OnTriggerStay(Collider other)
    {
        if (other.name == "FPSController")
        {
           
            if(!anim.GetBool("die")){
             other.gameObject.GetComponentInChildren<HealthBar>().Damage(damage);
            }
        }
    }
}
