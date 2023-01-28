using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    /*It is the class structure that allows the camera game object to follow the player target sent to it.*/
    private GameObject player;
    private Vector3 offset;
    private float speed = 10.0f;
    void Start()
    {
        player = GameObject.Find("Snake");
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, speed);
    }
}
