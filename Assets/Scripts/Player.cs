using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float px;
    private bool isGrounded = false;
    SpriteRenderer spi;
    Rigidbody2D rb;
    private GameObject player;
    Animator anim;
    private float speed = 5f;
    private bool coolDown = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>();
        spi = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Updates the variable that stores the player's x position for the comparison between the enemy and the player coords to determine the direction the enemy should go in
        px = player.transform.position.x;

        anim.SetBool("moving", false);
        anim.SetBool("attack1", false);

        if (Input.GetKey("q") == true)
        {
            anim.SetTrigger("attack1");
        }

        if (Input.GetKey("e") == true) //run
        {
            if (coolDown == false)
            {
                speed = speed + 0.05f;

                anim.SetBool("jumping", true);
            }
        }
        else
        {
            speed = 2;
        }

        //jumping

        //NOTE, FIX THE JUMPING SO YOU CANT FLY BY MAKING isGrounded WORK!!!!!

        if (Input.GetKey("w") == true)
        {
            if (isGrounded == false) //Set to true
            {
                rb.AddForce(new Vector3(0, 1, 0), ForceMode2D.Impulse);
                anim.SetBool("jumping", true);
                isGrounded = false;
            }
            else
            {
                anim.SetBool("jumping", false);
            }
        }

        //Left and right movement controls
        if (Input.GetKey("a") == true)
        {
            transform.position = new Vector2(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
            anim.SetBool("moving", true);
            spi.flipX = true;

        }
        if (Input.GetKey("d") == true)
        {
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            anim.SetBool("moving", true);
            spi.flipX = false;
        }
    }
}