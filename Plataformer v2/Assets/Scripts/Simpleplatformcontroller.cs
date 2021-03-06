﻿using UnityEngine;
using System.Collections;

public class Simpleplatformcontroller : MonoBehaviour {

    [HideInInspector] public bool facingright = true;
    [HideInInspector] public bool jump = false;

    public float moveforce = 365f;
    public float maxspeed = 5f;
    public float jumpforce = 1000f;
    public Transform groundcheck;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;
    private AudioSource audi;

    // Use this for initialization
    void Awake ()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        audi = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        grounded = Physics2D.Linecast(transform.position, groundcheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
	
	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxspeed)
        {
            rb2d.AddForce(Vector2.right * h * moveforce);
        }

        if (Mathf.Abs(rb2d.velocity.x) > maxspeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxspeed, rb2d.velocity.y);
        }
        if(h>0 && !facingright)
        {
            Flip();

        }

        else if (h < 0 && facingright)
        {
            Flip();
        }

        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpforce));
            audi.Play();
            jump = false;
        }
            
    }

    void Flip()
    {
        facingright = !facingright;
        Vector3 thescale = transform.localScale;
        thescale.x *= -1;
        transform.localScale = thescale; 
    }
}
