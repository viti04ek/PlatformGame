using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    public EnemyHealth EnemyHealth;

    public bool DieOnAnyCollision;


    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody && other.attachedRigidbody.GetComponent<Bullet>())
            EnemyHealth.TakeDamage(1);

        if (DieOnAnyCollision && !other.isTrigger)
            EnemyHealth.TakeDamage(10000);
    }
}
