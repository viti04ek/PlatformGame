using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}


public class Walker : MonoBehaviour
{
    public Transform LeftTarget;
    public Transform RightTarget;

    public float Speed;
    public float StopTime;

    public Direction CurrentDirection;

    private bool _isStopped;

    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;


    private void Start()
    {
        LeftTarget.parent = null;
        RightTarget.parent = null;
    }


    void Update()
    {
        if (_isStopped) return;


        if (CurrentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * Speed, 0, 0);

            if (transform.position.x < LeftTarget.position.x)
            {
                CurrentDirection = Direction.Right;

                _isStopped = true;
                Invoke("ContinueWalk", StopTime);

                EventOnLeftTarget.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * Speed, 0, 0);

            if (transform.position.x > RightTarget.position.x)
            {
                CurrentDirection = Direction.Left;

                _isStopped = true;
                Invoke("ContinueWalk", StopTime);

                EventOnRightTarget.Invoke();
            }
        }
    }


    void ContinueWalk()
    {
        _isStopped = false;
    }
}
