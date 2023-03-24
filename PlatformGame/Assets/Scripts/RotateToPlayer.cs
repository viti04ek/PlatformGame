using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    public Vector3 LeftEuler;
    public Vector3 Righteuler;

    public float RotationSpeed = 5;

    private Transform _playerTransform;
    private Vector3 _targerEuler;


    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }


    void Update()
    {
        if (transform.position.x < _playerTransform.position.x)
            _targerEuler = Righteuler;
        else
            _targerEuler = LeftEuler;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targerEuler), Time.deltaTime * RotationSpeed);

    }
}
