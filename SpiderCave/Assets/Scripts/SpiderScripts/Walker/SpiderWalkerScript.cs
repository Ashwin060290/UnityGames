using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalkerScript : MonoBehaviour {

    public float speed = 2f;

    private Rigidbody2D myBody;
    private bool collision;

    [SerializeField]
    private Transform startPosition, endPosition;
	// Use this for initialization
	void Awake () {
        myBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        ChangeDirection();
        Move();
    }

    void Move()
    {
        myBody.velocity = new Vector2(transform.localScale.x * speed, 0);
    }

    void ChangeDirection()
    {
        collision = Physics2D.Linecast(startPosition.position, endPosition.position, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawLine(startPosition.position, endPosition.position, Color.green);

        if(!collision)
        {
            Vector3 temp = transform.localScale;
            if (temp.x > 0)
                temp.x = -1 * Mathf.Abs(temp.x);
            else
                temp.x = Mathf.Abs(temp.x);

            transform.localScale = temp;
        }
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(collision.gameObject);
    }
}
