using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour, IDamageable {

    [Header("Base Stats")]
    public int MaxHealth = 100;

    [Header("Movement Values")]
    [SerializeField] public float MoveSpeed = 5f;
    [SerializeField] protected float _rotationSpeed = 10f;
    [SerializeField] protected float _gravity = 9.81f;

    public event Action OnCharacterDeath;

    protected float _currentHealth;
    protected IAttack _attackHandler;
    protected Vector2 _moveInput;
    protected CharacterController _cc;
    protected Vector3 _velocity;

    protected virtual void Awake() {
        _cc = GetComponent<CharacterController>();
        _currentHealth = MaxHealth;
        _attackHandler = GetComponent<IAttack>();
    }

    protected virtual void Update() {
        Move();
    }

    public virtual void SetMoveInput(Vector2 moveInput) {
        _moveInput = moveInput;
    }

    protected virtual void Move() {
        float horizontal = _moveInput.x;
        float vertical = _moveInput.y;


        if (Mathf.Abs(horizontal) > 0.01f) {
            float rotationAmount = horizontal * _rotationSpeed * Time.deltaTime;
            transform.Rotate(0f, rotationAmount, 0f);
        }

        Vector3 moveDir = transform.forward * vertical;
        _cc.Move(moveDir * MoveSpeed * Time.deltaTime);


        // Apply gravity
        _velocity.y += _gravity * Time.deltaTime;
        _cc.Move(_velocity * Time.deltaTime);

        // Reset vertical velocity if grounded
        if (_cc.isGrounded && _velocity.y < 0)
            _velocity.y = 0f;
    }

    public virtual void TakeDamage(int damageAmount) {
        GameManager.Instance.RaiseOnHitEvent(this, damageAmount);

        _currentHealth -= damageAmount;
        print($"I took damage! {_currentHealth} / {MaxHealth}");
        if (_currentHealth <= 0)
            Die();
    }

    protected virtual void Die() {
        OnCharacterDeath?.Invoke();
        Destroy(gameObject);
    }

    public virtual void PerformAttack() {
        _attackHandler?.ExecuteAttack();
    }

}

/*
 * 
 * 
    void HandleMoveInput(Vector2 moveInput) {

    }


    void OnEnable() {
        GameManager.Instance.Input.OnMoveInput += HandleMoveInput;
    }

    void OnDisable() {
        GameManager.Instance.Input.OnMoveInput -= HandleMoveInput;
    }

 */