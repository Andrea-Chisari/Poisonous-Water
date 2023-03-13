using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Movement_enemy : MonoBehaviour
{
    public Rigidbody rbe;

    public float moveSpeed = 10;
    //int enemyTimer;
    //public int enemyTimerlimit;
    bool enemyRunning_r = false;
    bool enemyRunning_l = false;
    public Transform pos;
    public int limit_l;
    public int limit_r;


    // Update is called once per frame
    void Update()
    {
        

        if (enemyRunning_l == true)
        {
            Vector3 enemyVector = Vector3.right * moveSpeed;

            rbe.velocity = enemyVector;
            //transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (enemyRunning_r == true)
        {
            Vector3 enemyVector = Vector3.left * moveSpeed;

            rbe.velocity = enemyVector;
            //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (pos.transform.position.x <= limit_l)
        {
            enemyRunning_r = false;
            enemyRunning_l = true;
        }

        if (pos.transform.position.x >= limit_r)
        {
            enemyRunning_l = false;
            enemyRunning_r = true;
        }
    }

    //private void FixedUpdate()
    //{
    //    enemyTimer = enemyTimer + 1;
    //}

}
