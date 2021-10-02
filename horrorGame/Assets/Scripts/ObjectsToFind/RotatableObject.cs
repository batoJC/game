using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableObject : MonoBehaviour
{

    public int Speed;

    //Axis in which the objects move
    //1,2,3 mean X,Y,Z respectively
    public char Axis;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
}
