using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//script de seguimiento del enemigo al jugador
public class Tracking : MonoBehaviour
{

    private Animator anim;

    public GameObject Enemy;
    private bool vision;
    private NavMeshHit hit;
    private bool stop = false;

    [Tooltip("Porcentaje de daño que causa este enemigo al jugador")]
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetInteger("attack", 0); //no attack;

        vision = NavMesh.Raycast(transform.position, Enemy.transform.position, out hit, NavMesh.AllAreas);



        // atacar desde cierta distancia
        if (hit.distance <= 4f && !vision)
        {
            Hit();
        }
        else
        {
            stop = false;
        }


        // perseguirlo si ha sido visto
        if (hit.distance < 20f && !vision && !stop && !anim.GetBool("die"))
        {
            this.gameObject.GetComponent<Creature>().SetPatrolling(false);
            Follow();
        }
        // si ya está muy lejos el jugador y no puede verlo, seguir patrullando
        if (hit.distance >= 20f)
        {
            anim.SetInteger("moving", 1); /// walk
            this.gameObject.GetComponent<Creature>().SetPatrolling(true);
            this.GetComponent<AudioSource>().Stop();
        }


    }

    void Follow()
    {

        anim.SetInteger("moving", 2); //run
        this.GetComponent<AudioSource>().Play();
        transform.LookAt(Enemy.transform.position);
    }

    void Hit()
    {
        anim.SetInteger("attack", 1);
    }

    void Stop()
    {
        anim.SetInteger("moving", 0);//idle
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSController")
        {
            Stop();
            stop = true;
            
        }

    }

    
}
