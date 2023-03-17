using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public bool Grounded;


    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed, 0, 0, ForceMode.Acceleration);
    }
}
