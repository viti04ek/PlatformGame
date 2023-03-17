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
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
            Rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
    }


    private void FixedUpdate()
    {
        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed, 0, 0, ForceMode.VelocityChange);

        Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
    }


    private void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);

        if(angle < 45)
            Grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }
}
