using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Platform_UD : MonoBehaviour
{
    public float moveSpeed = 10;
    bool moving_u = true;
    bool moving_d = false;
    public Button_platform click;
    public Transform pos;
    public bool canMove;

    public int limit_u;
    public int limit_d;

    // Start is called before the first frame update
    void Start()
    {
        //canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving_u == true && canMove == true)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }

        if (pos.transform.position.y >= limit_u)
        {
            moving_u = false;
            moving_d = true;
        }

        if (moving_d == true && canMove == true)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }

        if (pos.transform.position.y <= limit_d)
        {
            moving_d = false;
            moving_u = true;
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
