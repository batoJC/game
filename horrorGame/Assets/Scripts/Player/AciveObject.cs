using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AciveObject : MonoBehaviour
{

     public GameObject Boss;

     public GameObject Player;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float BossHealth  = Boss.GetComponent<HealthBar>().GetHealth();
        HealthBar[] bars = Player.GetComponents<HealthBar>();
        float MeteorBar = bars[1].GetHealth();

        foreach (Transform child in this.transform)
         {

            if((MeteorBar <= 0) && ((BossHealth >=70 && BossHealth <=75) || BossHealth>= 20 && BossHealth <= 25 )){
                child.gameObject.SetActive(true);
            }
        }
    }

   
}
