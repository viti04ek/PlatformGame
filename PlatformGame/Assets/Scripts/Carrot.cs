using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Rigidbody Rigidbody;

    public float Speed;


    void Start()
    {
        transform.rotation = Quaternion.identity;

        Transform playerTransform = FindObjectOfType<PlayerMove>().transform;

        Vector3 toPlayer = (playerTransform.position - transform.position);

        Rigidbody.velocity = toPlayer * Speed;
    }
}
