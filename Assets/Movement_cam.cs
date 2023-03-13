using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_cam : MonoBehaviour
{
    public Transform follow;
    public Vector3 distance;

    void Update()
    {
        transform.position = follow.position + distance;
    }
}
