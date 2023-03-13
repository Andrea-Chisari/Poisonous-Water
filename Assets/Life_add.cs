using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_add : MonoBehaviour
{
    [SerializeField] PlayerLife playerLife;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player");
        {
            if (playerLife.HP < 3)
            {
                Destroy(gameObject);
            }
                
        }
    }
}
