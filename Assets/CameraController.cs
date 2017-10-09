using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Vector3 offset;
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform player;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 destination = player.transform.position - offset;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}
