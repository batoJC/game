using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInPoints : MonoBehaviour
{

  public GameObject Enemy;
  private ArrayList points;
  private int indexPoint = 0;
  public float smooth = 2.5f;
  private GameObject personaje;
  private GameObject point;

  private bool vision;
  private UnityEngine.AI.NavMeshHit hit;
  private bool stop = false;

  private bool patrolling = true;
  private Animator anim;

  private State state = State.patrolling;
  enum State
  {
    patrolling,
    following,
    waiting

  }

  private bool following = false;
  // Start is called before the first frame update
  void Start()
  {
    // Save points for road
    this.points = new ArrayList();
    Transform[] allChildren = GetComponentsInChildren<Transform>();
    foreach (Transform child in allChildren)
    {
      if (child.gameObject.name.Contains("punto_"))
      {
        this.points.Add(child.gameObject);
      }
      if (child.gameObject.name == "personaje")
      {
        this.personaje = child.gameObject;
      }
    }


    anim = this.personaje.GetComponent<Animator>();
  }


  private void setStatusAndSound()
  {
    if (this.state == State.following)
    {
      this.personaje.GetComponent<AudioSource>().Play();
    }
    else
    {
      this.personaje.GetComponent<AudioSource>().Stop();
    }

    vision = !UnityEngine.AI.NavMesh.Raycast(this.personaje.transform.position, Enemy.transform.position, out hit, UnityEngine.AI.NavMesh.AllAreas);

    if (this.state == State.patrolling && vision)
    {
      this.state = State.following;

      return;
    }

    if (this.state == State.following && (!vision || hit.distance >= 20f))
    {
      this.state = State.waiting;

      return;
    }

    if (this.state == State.waiting && vision)
    {
      this.state = State.following;

      return;
    }
  }

  // Update is called once per frame
  void Update()
  {

    this.setStatusAndSound();

    switch (this.state)
    {
      case State.patrolling:
        walk();
        break;
      case State.following:
        run();
        break;
      case State.waiting:
        wait();
        break;
    }

    // atacar desde cierta distancia
    if (hit.distance <= 2f && vision)
    {
      this.personaje.GetComponent<AudioSource>().Play();
      attack();
      return;
    }

    // perseguirlo si ha sido visto
    if (hit.distance < 20f && this.state == State.following && !anim.GetBool("die"))
    {
      this.personaje.GetComponent<AudioSource>().Play();
      Follow();
    }

    if (this.state != State.patrolling || !setPoint())
    {
      return;
    }

    // if already in the point increment index
    var distance = (this.personaje.transform.position - this.point.transform.position).magnitude;
    if (distance < 1)
    {
      this.nextPoint();
    }

    var vector = Vector3.MoveTowards(this.personaje.transform.position, this.point.transform.position, Time.deltaTime * smooth);
    this.personaje.transform.position = vector;
  }

  void Follow()
  {
    this.personaje.transform.LookAt(Enemy.transform.position);
    var vector = Vector3.MoveTowards(this.personaje.transform.position, Enemy.transform.position, Time.deltaTime * smooth);
    this.personaje.transform.position = vector;
  }

  void attack()
  {
    anim.speed = 1f;
    this.smooth = 1f;
    anim.SetBool("attack", true);
    anim.SetBool("walk", false);
    anim.SetBool("wait", false);
  }

  void walk()
  {
    anim.speed = 1f;
    this.smooth = 1f;
    anim.SetBool("attack", false);
    anim.SetBool("walk", true);
    anim.SetBool("wait", false);
  }

  void wait()
  {
    anim.speed = 1f;
    this.smooth = 1f;
    anim.SetBool("attack", false);
    anim.SetBool("walk", false);
    anim.SetBool("wait", true);
  }

  void run()
  {
    anim.speed = 1f;
    this.smooth = 1.5f;
    anim.SetBool("attack", false);
    anim.SetBool("walk", true);
    anim.SetBool("wait", false);
  }

  void die()
  {
    anim.SetBool("die", true);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.name == "FPSController")
    {
      print("quitar vida");
    }
  }

  private void nextPoint()
  {
    this.indexPoint++;

    if (this.indexPoint >= this.points.Count)
    {
      this.indexPoint = 0;
    }
  }

  private bool setPoint()
  {
    if (this.points.Count == 0)
    {
      this.point = null;

      return false;
    }

    this.point = (GameObject)this.points[this.indexPoint];
    this.personaje.transform.LookAt(this.point.transform);

    return true;
  }
}
