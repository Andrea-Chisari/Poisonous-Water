using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_platform : MonoBehaviour
{
    public bool button_on = false;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            button_on = true;
            Destroy(gameObject);
        }
    }
}
