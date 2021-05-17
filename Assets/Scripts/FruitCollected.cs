using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollected : MonoBehaviour
{

	public AudioSource CollectSound;

	private void OnTriggerEnter2D(Collider2D collision){
		if (collision.CompareTag("Player")){
			GetComponent<SpriteRenderer>().enabled = false;
			gameObject.transform.GetChild(0).gameObject.SetActive(true);
			Destroy(gameObject, 0.5f);
			//CollectSound.Play();
		}
	}

    // Start is called before the first frame update
    void Start()
    {
        CollectSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
