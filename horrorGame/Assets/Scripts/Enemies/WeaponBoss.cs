using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoss : MonoBehaviour
{

    //Daño que ocasiona el arma del jefe
    public float damage;

    public GameObject Boss;

    private Boss BossScript;
  
    // Start is called before the first frame update
    void Start()
    {
        BossScript = Boss.GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.name == "FPSController"){
            if(BossScript.anim.GetInteger("attack") == 0){
                other.gameObject.GetComponentInChildren<HealthBar>().Damage(damage);
            }
        }
    }
}
