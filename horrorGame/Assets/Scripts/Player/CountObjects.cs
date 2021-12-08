using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountObjects : MonoBehaviour
{
    public int foundObjects = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.foundObjects = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.foundObjects > 6){
            print("Combatir con el boss");
        }
    }
}
