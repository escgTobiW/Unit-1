using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public bool isGrounded = false;
    SpriteRenderer spi;
    Rigidbody2D rb;
    public GameObject player;
    Animator anim;
    public float speed = 5f;
    public bool coolDown = false;
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

        anim.SetBool("moving", false);
        anim.SetBool("attack1", false);
        if (isGrounded == true)
        {
            anim.SetBool("jumping", false);
        }

        if (Input.GetKey("q") == true)
        {
            anim.SetTrigger("attack1");
            anim.speed = 5;
        }

        if (Input.GetKey("e") == true) //run
        {
            if (coolDown == false)
            {
                speed = 9;
                anim.speed = 5;
            }
        }
        else
        {
            speed = 5;
            anim.speed = 1;
        }

        //jumping

        //NOTE, FIX THE JUMPING SO YOU CANT FLY BY MAKING isGrounded WORK!!!!!

        if (Input.GetKey("w") == true)
        {
            if (isGrounded == true) //Set to true
            {
                rb.AddForce(new Vector3(0, 30, 0), ForceMode2D.Impulse);
                anim.SetBool("jumping", true);
                isGrounded = false;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}