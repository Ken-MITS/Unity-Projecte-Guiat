using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
	public GameObject player;
	public GameObject tilemap;
	public GameObject rock;
	
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("NinjaFrog");
        tilemap= GameObject.Find("Tilemap");
        rock = GameObject.Find("rock");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   	public void OnTriggerEnter2D(Collider2D collision){
   		if (collision.CompareTag("Player")){
			tilemap.transform.localRotation *= Quaternion.Euler(0, 180, 180);
			rock.transform.localRotation *= Quaternion.Euler(0, 180, 180);
			
			//float speed = 10F; 
			//player.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(180, 0, 0), Time.deltaTime * speed);   			
   		}
   		
   	}
    
}
