using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<Health> OnDamaged;

    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _particleSystem;
    public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }

    public bool IsDead => CurrentHealth <= 0;
    public void SetHealth(float maxhealth)
    {
        MaxHealth = maxhealth;
        CurrentHealth = maxhealth;
    }

    private void Awake() => _particleSystem.Stop();


    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        _particleSystem.Play();
        _animator.SetTrigger("Hited");
        OnDamaged?.Invoke(this);

        if(IsDead)
        {
            Dead();
        }
    }

    private void Dead() => _animator.SetTrigger("Dead");
}
