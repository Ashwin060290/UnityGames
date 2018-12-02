using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float moveForce = 70f, jumpForce = 700f, maxVelocity = 4f;

    private Rigidbody2D myBody;
    private Animator anim;

    private bool grounded = true;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        myBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();

    }

    private void MovePlayer()
    {
        float forceX = 0f, forceY = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                if (grounded)
                    forceX = moveForce;
                else
                    forceX = moveForce * 1.1f;
            }
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        }

        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                if (grounded)
                    forceX = -moveForce;
                else
                    forceX = -moveForce * 1.1f;
            }
            Vector3 scale = transform.localScale;
            scale.x = -1f * Mathf.Abs(scale.x);
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        }

        else if (h == 0)
        {
            anim.SetBool("Walk", false);
            //myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false; ;
                forceY = jumpForce;
            }

        }

        myBody.AddForce(new Vector2(forceX, forceY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
