using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RopeState
{
    Disabled,
    Fly,
    Active
}


public class RopeGun : MonoBehaviour
{
    public Hook Hook;
    public Transform Spawn;
    public float Speed;

    public SpringJoint SpringJoint;

    public Transform RopeStart;

    private float _lenght;

    public RopeState CurrentRopeState;


    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            Shot();
        }

        if (CurrentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(RopeStart.position, Hook.transform.position);

            if (distance > 20)
            {
                Hook.gameObject.SetActive(false);
                CurrentRopeState = RopeState.Disabled;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroySpring();
        }
    }


    void Shot()
    {
        if (SpringJoint)
            Destroy(SpringJoint);

        Hook.gameObject.SetActive(true);

        Hook.StopFix();

        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;

        Hook.Rigidbody.velocity = Spawn.forward * Speed;

        CurrentRopeState = RopeState.Fly;
    }


    public void CreateSpring()
    {
        if (SpringJoint == null)
        {
            SpringJoint = gameObject.AddComponent<SpringJoint>();

            SpringJoint.connectedBody = Hook.Rigidbody;
            SpringJoint.anchor = RopeStart.localPosition;
            SpringJoint.autoConfigureConnectedAnchor = false;
            SpringJoint.connectedAnchor = Vector3.zero;
            SpringJoint.spring = 100f;
            SpringJoint.damper = 5f;

            _lenght = Vector3.Distance(RopeStart.position, Hook.transform.position);
            SpringJoint.maxDistance = _lenght;

            CurrentRopeState = RopeState.Active;
        }
    }


    public void DestroySpring()
    {
        if (SpringJoint)
        {
            Destroy(SpringJoint);
            CurrentRopeState = RopeState.Disabled;
            Hook.gameObject.SetActive(false);
        }
    }
}
