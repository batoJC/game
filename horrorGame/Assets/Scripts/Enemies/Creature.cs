using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{

    private Animator anim;
	//private CharacterController controller;
	private int battle_state = 0;
	public float speed = 6.0f;
	public float runSpeed = 3.0f;
	public float turnSpeed = 60.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	private float w_sp = 0.0f;
	private float r_sp = 0.0f;

    private Vector3 endPoint;
    private Vector3 startPoint;
    private Vector3 nextPoint;
    private bool flagDirection = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //w_sp = speed; //read walk speed
		r_sp = runSpeed; //read run speed
		//controller = GetComponent<CharacterController> ();

        endPoint = GameObject.Find("point1").gameObject.transform.position;
        startPoint = this.transform.position;
        nextPoint = endPoint;
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetInteger ("moving", 0); // idle
        anim.SetInteger ("moving", 1);//walk

		//runSpeed = 1;
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
            transform.LookAt(nextPoint); 
        }
    }
}
