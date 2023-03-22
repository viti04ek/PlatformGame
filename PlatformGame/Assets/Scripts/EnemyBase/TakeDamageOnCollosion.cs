using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollosion : MonoBehaviour
{
    public EnemyHealth EnemyHealth;

    public bool DieOnAnyCollision;


    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.rigidbody && collision.rigidbody.GetComponent<Bullet>() )
            EnemyHealth.TakeDamage(1);

        if (DieOnAnyCollision)
            EnemyHealth.TakeDamage(10000);
    }
}
