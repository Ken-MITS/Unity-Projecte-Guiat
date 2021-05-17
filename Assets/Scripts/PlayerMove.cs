using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
	public static int lifes = 2;
	public float runSpeed = 2;
	public float jumpSpeed = 3;
	public static bool isDead = false;
	public static bool flipX = false;
	public static int jumpCount = 0;
	public static bool isOnDoor1 = false, isOnDoor2 = false;
	
	Rigidbody2D rb;
	SpriteRenderer sr;
	Animator an;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        if(!isDead){
		    if (Input.GetKey("d") || Input.GetKey("right")){
		    	pos.x += runSpeed * Time.deltaTime;
		    	sr.flipX = false;
		    	an.SetBool("Run", true);	
		    }else if(Input.GetKey("a") || Input.GetKey("left")){
		    	pos.x -= runSpeed * Time.deltaTime;
		    	sr.flipX = true;
		    	an.SetBool("Run", true);
		    }else{
		    	an.SetBool("Run", false);
		    }
		    transform.position = pos;
		    
		    if((Input.GetKeyDown("w") || Input.GetKeyDown("space")) && CheckGround.isGrounded){
				rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
				jumpCount++;
				Debug.Log("Count: "+jumpCount);
				
			}else if ((Input.GetKeyDown("w") || Input.GetKeyDown("space")) && !CheckGround.isGrounded){
				Debug.Log("else if: "+jumpCount);
				if (jumpCount == 0){
					rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
					an.SetBool("DoubleJump", true);
				}
				jumpCount++;
			}
			
			if(CheckGround.isGrounded == false){
				an.SetBool("Jump", true);	
			}else if (CheckGround.isGrounded){
				jumpCount = 0;
				an.SetBool("Jump", false);	
				an.SetBool("DoubleJump", false);
			}else{
				Debug.Log("else, is grounded // !isGrounded");
			}
			if (pos.y < -3){
				die();
				Debug.Log("dead");		
			}
		}
		if (isOnDoor1 && Input.GetKeyDown("e")){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}else if (isOnDoor2 && Input.GetKeyDown("e")){
			SceneManager.LoadScene(2);
		}
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
    	Vector2 pos = transform.position;
		if (collision.CompareTag("Trap")){
			lifes--;
			Debug.Log("Collision");
			an.SetBool("Hit", true);
			rb.velocity = new Vector2(rb.velocity.x, runSpeed);
			if (lifes==0){ 
				isDead = true;
				die();
			}
			
		}else if (collision.CompareTag("boost")){
			rb.velocity = new Vector2(rb.velocity.x, jumpSpeed+2);
		}else {
			an.SetBool("Hit", false);
		}
		
		if (collision.gameObject.name == "door1"){
			isOnDoor1 = true;
		}
		if (collision.gameObject.name == "door2"){
			isOnDoor2 = true;
		}
		
	}
	
	private void OnTriggerExit2D(Collider2D collision){
		if (collision.gameObject.name == "door1"){
			isOnDoor1 = false;
		}
		if (collision.gameObject.name == "door2"){
			isOnDoor2 = false;
		}
	}
	
	private void die(){
		//Destroy(gameObject, 1.0f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		lifes = 2;
		an.SetBool("DoubleJump", false);
		Start();
	}
	
    
    
    
    
    
    
    
    
    
    
    
}
