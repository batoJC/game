using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInPoints : MonoBehaviour
{
    private ArrayList points;
    private int indexPoint = 0;
    public float smooth = 1.5f;
    private GameObject personaje;
    private GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        // Save points for road
        this.points = new ArrayList();
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if(child.gameObject.name.Contains("punto_")){
                this.points.Add(child.gameObject);
            }
            if(child.gameObject.name == "personaje"){
                this.personaje = child.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!setPoint()){
            return;
        }
        // if already in the point increment index
        var distance = (this.personaje.transform.position - this.point.transform.position).magnitude;
        if(distance < 1){
            this.nextPoint();
        }



        var vector = Vector3.MoveTowards(this.personaje.transform.position,this.point.transform.position, Time.deltaTime * smooth);
        this.personaje.transform.position = vector;
    }

    private void nextPoint(){
        this.indexPoint++;

        if(this.indexPoint >= this.points.Count){
            this.indexPoint = 0;
        }
    }

    private bool setPoint(){
        if(this.points.Count ==  0 ){
            this.point = null;

            return false;
        }

        this.point = (GameObject)this.points[this.indexPoint];

        return true;
    }
}
