using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private float _health;
    private float _maxHealth = 100f;

    public bool IsDead => _health <= 0;

    private void Start() => _health = _maxHealth;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if(IsDead)
        {
            Dead();
        }
    }

    private void Dead() => _animator.SetTrigger("Dead");
}
