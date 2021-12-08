using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountObjects : MonoBehaviour
{
    public int foundObjects = 0;

     AsyncOperation async;

    // Start is called before the first frame update
    void Start()
    {
        this.foundObjects = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.foundObjects > 6){
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {

        async = Application.LoadLevelAsync("BossScene");

        yield return async;
    }
}
