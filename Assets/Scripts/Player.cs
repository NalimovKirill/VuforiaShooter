using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private int _health;
    [SerializeField] private float _secondsBetweenShoot;

    private float _lastShootTime;
    private Animator _animator;

    public int Health => _health;
    public event UnityAction<int> HealthChanged;
    public event UnityAction Die;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastShootTime <= 0)
        {
            _animator.Play("Shoot");
            _weapon.Shoot();
            _lastShootTime = _secondsBetweenShoot;
        }
        _lastShootTime -= Time.deltaTime;

        
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);
        if (_health <= 0)
        {
            Die?.Invoke();
        }
    }
    public void Idle()
    {
        _animator.Play("Idle");
    }

   
}
