using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_player : MonoBehaviour
{
    public Rigidbody rb;

    //variabili movement
    [Header("Movement")]
    public float moveSpeed = 10;

    //variabili salto
    [Header("Jump")]
    public int timerlimit;
    int timer;
    public bool isGrounded = true;
    public bool canjump = true;
    public float gravity;
    public float jumpForce;

    //variabili wallclimb
    [Header("Climb")]
    public float wallclimbForce;
    public bool canclimb = false;
    int walltimer;
    public int walltimerlimit;
    public bool climb_l_exit = false;
    public bool climb_r_exit = false;

    //variabili dash
    [Header("Dash")]
    public float dashForce;
    bool dash_l = false;
    bool dash_r = false;
    bool dashmove_r = false;
    bool dashmove_l = false;
    int dashtime_l;
    int dashtime_r;
    float antigravity = 1;

    //variabile piattaforma
    bool OnPlatform = false;

    void Update()
    {

        //antigravity
        if (Input.GetKeyUp("space") && canclimb == true && dash_l == true)
        {
            dashmove_r = true;
            antigravity = 0;
        }

        if (Input.GetKeyUp("space") && canclimb == true && dash_r == true)
        {
            dashmove_l = true;
            antigravity = 0;
        }

        if (Input.GetKey("space"))
        {
            dashmove_r = false;
            antigravity = 1;
        }

        if (Input.GetKey("space"))
        {
            dashmove_l = false;
            antigravity = 1;
        }

        //dash

        if (dash_l == true)
        {
            dashtime_l = dashtime_l + 1;

        }

        if (dash_r == true)
        {
            dashtime_r = dashtime_r + 1;

        }

        if (dash_l == false)
        {
            dashtime_l = 0;

        }

        if (dash_r == false)
        {
            dashtime_r = 0;
        }
    }
    private void FixedUpdate()
    {
        RigidbodyMove();
        RigidbodyJump();
        RigidBodyWallClimb();
        RigidBodyDash();


        //jump
        if (isGrounded == false)
        {
            timer = timer + 1;
        }

        if (isGrounded == true)
        {
            timer = 0;
        }


        //wall climb

        if (canclimb == false)
        {
            walltimer = walltimer + 1;
        }


        if (canclimb == true)
        {
            walltimer = 0;
        }

        //gravity

        if (!OnPlatform)
        {
            rb.AddForce(Vector3.down * gravity * antigravity);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            }
        }

        else
        {
            Vector3 newVelocity = rb.velocity;
            newVelocity.y = 0;
            rb.velocity = newVelocity;
        }


    }


    void RigidbodyMove()
    {
        //Movimento (axisraw = unico, axis = curva)
        if (dashmove_r == false && dashmove_l == false)
        {
            float xMove = Input.GetAxisRaw("Horizontal");
            Vector3 movementVector = Vector3.right * xMove * Time.deltaTime * moveSpeed;

            rb.velocity = movementVector;
        }


    }

    void RigidbodyJump()
    {
        if (isGrounded == true)
        {
            if (timer == 0)
            {
                canjump = true;
            }

        }


        if (Input.GetKeyUp("space"))
        {
            if (timer > 0)
            {
                canjump = false;
            }
        }


        if (Input.GetKey("space") && timer < timerlimit && dash_l == false && dash_r == false && canjump == true && canclimb == false)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            climb_r_exit = false;
            climb_l_exit = false;
        }

    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "roof")
        {
            canjump = false;
            dash_l = false;
            dash_r = false;
        }

        if (collision.gameObject.tag == "wall_l")
        {
            dash_l = true;
            canclimb = true;
            dashmove_l = false;
            dash_r = false;
            antigravity = 1;
            climb_l_exit = true;
            climb_r_exit = false;
        }


        if (collision.gameObject.tag == "wall_r")
        {
            dash_r = true;
            canclimb = true;
            dashmove_r = false;
            dash_l = false;
            antigravity = 1;

        }

        if (collision.gameObject.tag == "ground")
        {

            dashmove_l = false;
            dashmove_r = false;
            antigravity = 1;
            climb_r_exit = false;
            climb_l_exit = false;
        }


        if (collision.gameObject.tag == "platform")
        {
            isGrounded = true;
            OnPlatform = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {


        if (collision.gameObject.tag == "wall_l")
        {
            dash_l = false;
            canclimb = false;
            if (climb_l_exit == true)
            {
                transform.position = transform.position + new Vector3(-1, 1, 0);
            }
        }

        if (collision.gameObject.tag == "wall_r")
        {
            dash_r = false;
            canclimb = false;
            if (climb_r_exit == true)
            {
                transform.position = transform.position + new Vector3(1, 1, 0);
            }

        }

        if (collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        }

        if (collision.gameObject.tag == "platform")
        {
            isGrounded = false;
            OnPlatform = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            climb_r_exit = false;
            climb_l_exit = false;
            isGrounded = true;
            canjump = true;
        }

        //if (collision.gameObject.tag == "wall_r")
        //{
        //    climb_r_exit = true;
        //    climb_l_exit = false;
        //}

        //if (collision.gameObject.tag == "wall_l")
        //{
        //    climb_r_exit = false;
        //    climb_l_exit = true;
        //}
    }

    void RigidBodyWallClimb()
    {
        if (Input.GetKey("a"))
        {
            climb_r_exit = false;
        }

        else
        {
            climb_r_exit = true;
        }

        if (Input.GetKey("d"))
        {
            climb_l_exit = false;
        }

        else
        {
            climb_l_exit = true;
        }


        if (walltimer < walltimerlimit && Input.GetKey("w") && dashmove_l == false && dashmove_r == false)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * wallclimbForce);
        }

    }

    void RigidBodyDash()
    {
        if (dashmove_r == true && isGrounded == false && dashtime_l > 0)
        {
            //float dashMove = Input.GetAxisRaw("Jump");
            Vector3 dashVector = Vector3.right * dashForce;

            rb.velocity = dashVector;
            climb_r_exit = false;
            climb_l_exit = false;
        }


        if (dashmove_l == true && isGrounded == false && dashtime_r > 0)
        {
            //float dashMove = Input.GetAxisRaw("Jump");
            Vector3 dashVector = Vector3.left * dashForce;

            rb.velocity = dashVector;
            climb_r_exit = false;
            climb_l_exit = false;
        }
    }
}
