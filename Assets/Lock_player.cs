using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_player : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }

    }
}
