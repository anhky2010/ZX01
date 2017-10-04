using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    public Transform player;
    public Vector3 offset;
    public float smoothSpeed;
    // Use this for initialization
    void Start()
    {
        this.transform.position = player.position - offset;
    }
    float distance = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        //distance = this.transform.position.x - player.position.x;
        //if (Mathf.Abs(distance) > 10)
        //{
        //    this.transform.position = Vector3.MoveTowards(this.transform.position, player.position - offset, smoothSpeed);
        //}
        this.transform.position = player.position - offset;
    }
}
