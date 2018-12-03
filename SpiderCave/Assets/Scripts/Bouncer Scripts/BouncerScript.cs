using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerScript : MonoBehaviour {

    private Animator anim;

    public float force = 500f;
	// Use this for initialization
	void Awake () {
        anim = gameObject.GetComponent<Animator>();
	}
	
    IEnumerator BounceAnimation()
    {
        anim.Play("Up");
        yield return new WaitForSeconds(0.5f);
        anim.Play("Down");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            StartCoroutine(BounceAnimation());
            collider.gameObject.GetComponent<PlayerScript>().BouncePlayerOnBouncer(force);
            
        }
    }
	
}
