using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour
{
    //public Rigidbody wf;
    public Button_waterfall click;
    public CharacterController controller;
    int timer;
    public int timerLimit;

    Vector3 fall; 

    // Update is called once per frame
    void Update()
    {
        if (click.button_on)
        {

            //transform.position = new Vector3(transform.position.x, transform.position.y - 100, transform.position.z);

            //Vector3 newPos = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
            //transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime);

            //fall = transform.TransformDirection(Vector3.down);
            //controller.SimpleMove (fall * 500);

            transform.Translate(Vector3.down * 50 * Time.deltaTime);
        }

        if (timer >= timerLimit)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (click.button_on)
        {
            timer = timer + 1;
        }
    }
}
