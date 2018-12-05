using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowScript : MonoBehaviour {

    private Transform playerTransform;

    public float minX, maxX;

	// Use this for initialization
	void Awake () {
        playerTransform = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(playerTransform != null)
        {
            Vector3 temp = transform.position;
            temp.x = playerTransform.position.x;
            temp.y = playerTransform.position.y + 2f;
            transform.position = temp;
        }
	}
}
