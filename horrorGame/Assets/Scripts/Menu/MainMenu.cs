using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    private Text text ;
    AsyncOperation async;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    void OnMouseOver()
    {
        //Change color to red when mouse over
        text.color = Color.red;
    }

    void OnMouseExit()
    {

	    text.color = Color.white;		//Change Color to white!
    }

    // Update is called once per frame
    void Update()
    {
        //If you press (escape) game force closes!
        if (Input.GetKey(KeyCode.Escape)) 
        {
            Application.Quit();
        }
         
    }

    //OnMouseUp is called when the user has released the mouse button.
    void OnMouseUp()
    {
        if(this.name == "Quit" ){
            Application.Quit();
            print("quit");
        }
        if(this.name == "Play"){
            StartCoroutine(LoadScene());
        }
        
    }

    IEnumerator LoadScene()
    {

        async = Application.LoadLevelAsync("demo1");

        yield return async;
    }


}
