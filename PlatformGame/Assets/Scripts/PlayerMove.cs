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

    public float MaxSpeed;

    public Transform ColliderTransform;

    public Transform BodyTransform;
    public Transform Target;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
            Jump();


        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || !Grounded)
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1, 0.5f, 1), Time.deltaTime * 15);
        else
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1, 1, 1), Time.deltaTime * 15);


        if (Target.position.x > BodyTransform.position.x)
            BodyTransform.rotation = Quaternion.Lerp(BodyTransform.rotation, Quaternion.Euler(0, -45, 0), 0.5f);
        else
            BodyTransform.rotation = Quaternion.Lerp(BodyTransform.rotation, Quaternion.Euler(0, 45, 0), 0.5f);
    }


    public void Jump()
    {
        Rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
    }


    private void FixedUpdate()
    {
        float speedMultiplier = 1;

        if (!Grounded)
        {
            speedMultiplier = 0.2f;

            if ((Rigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0) || (Rigidbody.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0))
                speedMultiplier = 0;
        }


        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);


        if (Grounded)
            Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
    }


    private void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);

        if (angle < 45)
            Grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }
}
