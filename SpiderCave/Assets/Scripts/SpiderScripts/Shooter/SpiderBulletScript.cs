using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBulletScript : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }

        if(collider.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
