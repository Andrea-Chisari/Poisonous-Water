using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    
    //public float checkpoint_x;
    //public float checkpoint_y;
    
    public Transform player;

 
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerLife>().checkpoint_x = player.transform.position.x;
            player.GetComponent<PlayerLife>().checkpoint_y = player.transform.position.y;            
        }
    }

}
