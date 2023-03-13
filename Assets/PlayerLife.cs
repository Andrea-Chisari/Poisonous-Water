using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int HP = 3;
    public Text Text;
    public Checkpoint checkpoint;
    public float checkpoint_x;
    public float checkpoint_y;

    // Update is called once per frame
    void Update()
    {
        
        Text.text = "x" + HP;

        if (HP == 0)
        {
            //SceneManager.LoadScene("SampleScene");
            transform.position = new Vector3(checkpoint_x, checkpoint_y, 0);
            HP = 3;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            HP = HP - 1;
        }

        if (collision.gameObject.tag == "acid")
        {
            HP = 0;
        }
    }

    void OnTriggerEnter(Collider collision)
    {


        if (collision.gameObject.tag == "heart")
        {
            HP = HP + 1;
        }

        if (collision.gameObject.tag == "gold_heart")
        {
            HP = 3;
        }

        if (HP == 4)
        {
            HP = HP - 1;
        }
    }


}
