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
        if (Input.GetKey("w") == true)
        {
            if (isGrounded == true)
            {
                rb.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
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