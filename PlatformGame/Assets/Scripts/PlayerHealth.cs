using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public int MaxHealth = 8;

    private bool _invulnerable = false;

    public AudioSource TakeDamageSound;
    public AudioSource AddHealthSound;


    public void TakeDamage(int damageValue)
    {
        if (!_invulnerable)
        {
            Health -= damageValue;

            if (Health <= 0)
            {
                Health = 0;

                Die();
            }

            _invulnerable = true;
            Invoke("StopInvulnerable", 1);

            TakeDamageSound.Play();
        }
    }


    void Die()
    {

    }


    void StopInvulnerable()
    {
        _invulnerable = false;
    }


    public void AddHealth(int healthValue)
    {
        Health += healthValue;

        if (Health > MaxHealth)
            Health = MaxHealth;

        AddHealthSound.Play();
    }
}
