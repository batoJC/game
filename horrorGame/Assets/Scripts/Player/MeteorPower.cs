using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPower : MonoBehaviour
{

   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "FPSController"){ 
            this.gameObject.SetActive(false);
            HealthBar[] bars = other.gameObject.GetComponentsInChildren<HealthBar>();
            bars[1].Heal(100f);
        }
        
    }
}
