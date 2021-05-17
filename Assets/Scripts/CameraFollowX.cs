using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowX : MonoBehaviour
{

	public GameObject player;
	

    // Start is called before the first frame update
    void Start()
    {
    	player = GameObject.Find("NinjaFrog");
    }

    // Update is called once per frame
    void Update()
    {
    	Vector3 pos = transform.position;
        pos.x = player.transform.position.x;
        transform.position = pos;
    }
}
