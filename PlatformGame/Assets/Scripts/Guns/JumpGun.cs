using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public float Speed;
    public Transform Spawn;
    public Gun Gun;

    public float MaxCharge = 3;
    private float _currentCharge;
    private bool _isCharged;


    private void Update()
    {
        if (_isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                PlayerRigidbody.AddForce(-Spawn.forward * Speed, ForceMode.VelocityChange);
                Gun.Shot();

                _isCharged = false;
                _currentCharge = 0;
            }
        }
        else
        {
            _currentCharge += Time.deltaTime;

            if (_currentCharge >= MaxCharge)
                _isCharged = true;
        }
    }
}
