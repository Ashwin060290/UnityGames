using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumperScript : MonoBehaviour {

    public float jumpForce = 350f;

    private Animator anim;
    private Rigidbody2D myBody;


    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        myBody = gameObject.GetComponent<Rigidbody2D>();
    }
		
	// Update is called once per frame
	void Start () {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2,7));

        anim.SetBool("Attack", true);
        float forceY = Random.Range(250, 550);
        jumpForce = forceY;
        myBody.AddForce(new Vector2(0,jumpForce));

        yield return new WaitForSeconds(0.7f);

        StartCoroutine(Attack());
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Ground")
        {
            anim.SetBool("Attack", false);
        }

        if(collider.tag == "Player")
        {
            Destroy(collider.gameObject);
        }
    }
}
