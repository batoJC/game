using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
Script patrolling
**/
public class Creature : MonoBehaviour
{

    private Animator anim;

    private Vector3 endPoint;
    private Vector3 startPoint;
    private Vector3 nextPoint;
    private bool flagDirection = true;
    private bool patrolling = true;

    // Start is called before the first frame update
    void Start()
    {

       
        anim = GetComponent<Animator>();
        //w_sp = speed; //read walk speed
		//r_sp = runSpeed; //read run speed
		//controller = GetComponent<CharacterController> ();

        endPoint = GameObject.Find("point1").gameObject.transform.position;
        startPoint = this.transform.position;
        nextPoint = endPoint;
    }

    // Update is called once per frame
    void Update()
    {

        if(patrolling){

            anim.SetInteger("moving",1); /// walk
            float distance = Vector3.Distance(this.transform.position,nextPoint);

            if(distance < 1.0){
               if (flagDirection)
               {
                   nextPoint = startPoint;
                   flagDirection = false; 
                }
                else{
                    nextPoint = endPoint;
                    flagDirection = true;
                }
                
            }
            transform.LookAt(nextPoint); 
            
        }        
    }

    public bool GetPatrolling(){
        return this.patrolling;
    }

    public void SetPatrolling(bool newPatrolling){
        this.patrolling = newPatrolling;
    }
}
