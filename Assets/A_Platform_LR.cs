using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Platform_LR : MonoBehaviour
{
    public float moveSpeed = 10;
    bool moving_l = true;
    bool moving_r = false;
    public Button_platform click;
    public Transform pos;
    public bool canMove;

    public int limit_l;
    public int limit_r;

    // Start is called before the first frame update
    void Start()
    {
        //canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving_l == true && canMove == true)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (pos.transform.position.x >= limit_r)
        {
            moving_l = false;
            moving_r = true;
        }

        if (moving_r == true && canMove == true)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (pos.transform.position.x <= limit_l)
        {
            moving_r = false;
            moving_l = true;
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            trigger.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            trigger.gameObject.transform.SetParent(null);
        }
    }


    private void FixedUpdate()
    {
        if (click.button_on)
        {
            canMove = true;
        }
    }
}
