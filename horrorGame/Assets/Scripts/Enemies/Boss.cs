using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{

    //Player is the enemy
    public GameObject Player;

    //Navegation
    NavMeshAgent Agent;

    //Animations
    public Animator anim;

    HealthBar HealthBar;

    private bool colision;

    public float DistanceAttack;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        HealthBar = GetComponent<HealthBar>();
        colision = false;
    }

    // Update is called once per frame
    void Update()
    {

        
        Vector3 PlayerPosition = Player.transform.position;
        if(!colision && !anim.GetBool("die")){
            //always follow the player
            Follow(PlayerPosition);
        }

         //atacar desde cierta distancia
        float distance = Vector3.Distance(this.transform.position, PlayerPosition);
        if(distance < DistanceAttack && !anim.GetBool("die")){
            Attack();
        }
        else{
            StopAttack();
        }

        if(HealthBar.GetHealth() >= 40 && HealthBar.GetHealth() <= 50){
            FloatFaster(6);
        }
        
    }

    public void Attack(){
        anim.SetInteger("attack",0);
    }

    public void StopAttack(){
        anim.SetInteger("attack",-1);
    }

    public void FloatFaster(float newSpeed){
        Agent.speed =+ newSpeed;
        print(Agent.speed);
    }


    void Follow(Vector3 newPosition){
        Agent.destination = newPosition;
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.name == "FPSController"){
            colision = true;
           
            
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.name == "FPSController"){
            colision = false;
            
        };
    }
}
