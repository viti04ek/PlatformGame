using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeGun : MonoBehaviour
{
    public Hook Hook;
    public Transform Spawn;
    public float Speed;


    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            Shot();
        }
    }


    void Shot()
    {
        Hook.StopFix();

        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;

        Hook.Rigidbody.velocity = Spawn.forward * Speed;
    }
}
