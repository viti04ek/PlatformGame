using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeGun : MonoBehaviour
{
    public Hook Hook;
    public Transform Spawn;
    public float Speed;

    public SpringJoint SpringJoint;


    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            Shot();
        }
    }


    void Shot()
    {
        if (SpringJoint)
            Destroy(SpringJoint);

        Hook.StopFix();

        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;

        Hook.Rigidbody.velocity = Spawn.forward * Speed;
    }


    public void CreateSpring()
    {
        if (SpringJoint == null)
        {
            SpringJoint = gameObject.AddComponent<SpringJoint>();

            SpringJoint.connectedBody = Hook.Rigidbody;
            SpringJoint.autoConfigureConnectedAnchor = false;
            SpringJoint.connectedAnchor = Vector3.zero;
            SpringJoint.spring = 100f;
            SpringJoint.damper = 5f;
            SpringJoint.maxDistance = 3f;
        }
    }
}
