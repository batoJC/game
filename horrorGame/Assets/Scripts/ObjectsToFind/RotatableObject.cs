using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableObject : MonoBehaviour
{

    AudioSource audioSource;
    public GameObject personaje;
    public int Speed;

    public int damage = 30;
    public int health = 30;

    //Axis in which the objects move
    //1,2,3 mean X,Y,Z respectively
    public char Axis;
    private HealthBar healthScript;
    private CountObjects foundScript;
    private bool counted = false;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        healthScript = this.personaje.GetComponent<HealthBar>();
        foundScript = this.personaje.GetComponent<CountObjects>();

    }

    // Update is called once per frame
    void Update()
    {

         // if already in the point increment index
        var distance = (this.personaje.transform.position - this.transform.position).magnitude;

        audioSource.mute = distance > 10;
       Rotate();
    }

    void Rotate(){

        //Rotate in X
        if(char.ToLower(Axis) == 'x'){
            transform.Rotate(Time.deltaTime * Speed, 0, 0);
        }
        //Rotate in Y
        if(char.ToLower(Axis) == 'y'){
            transform.Rotate(0, Time.deltaTime * Speed, 0);
        }
        //Rotate in Z
        if(char.ToLower(Axis) == 'z'){
            transform.Rotate(0, 0, Time.deltaTime * Speed);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.name == "FPSController"){
            print("collitions");
            healthScript.Heal(health);
            Destroy(gameObject,1);
            if(!this.counted){
                this.counted = true;
                foundScript.foundObjects++;
            }
        }
    }
}
