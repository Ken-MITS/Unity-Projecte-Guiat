using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitManager : MonoBehaviour
{

	private float totalTime;
	private bool collectedAll =  false;
	public GameObject win;
	//public GameObject text;
	
    // Start is called before the first frame update
    void Start()
    {
    	win = GameObject.Find("Text");
    	win.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    	if (collectedAll && (Time.time - totalTime > 5f)){
    		collectedAll = false;
    		SceneManager.LoadScene(0);
    	}
        allFruitsCollected();
    }
    
    public void allFruitsCollected(){
    	if (transform.childCount == 0){
    		
    		//Debug.Log(SceneManager.GetActiveScene().buildIndex);
    		if (SceneManager.GetActiveScene().buildIndex == 2){
    			totalTime = Time.time;
    			collectedAll = true;
    			win.SetActive(true);
    			//SceneManager.LoadScene(0);
    		}else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    	}
    } 
}
