using System.Collections;
using UnityEngine;
public class Character : IDamageable
{
    [Header("Character Stats")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;

    [Header("Animations")]
    [SerializeField] private Animator _animator;

    [Header("Util")]
    [SerializeField] public Transform CastArm;
    [SerializeField] public Transform CastPoint;

    private Vector2 _lastDirection;
    private Rigidbody2D _rb;

    public override void OnTakeDamage()
    {
        Debug.Log("Ouch!");
    }

    public Vector2 GetDirection()
    { 
        return _lastDirection; 
    }

    public void MoveTowards(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            return;
        }

        _rb.AddForce(direction * _movementSpeed * Time.deltaTime);

        if(direction != _lastDirection) 
        {
            if (direction.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            _lastDirection = direction;
        }
    }

    public void Jump()
    {
        _animator.SetTrigger("Jump"); 
        _rb.velocity = Vector3.zero;
        _rb.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
    }
    private void Die()
    {
    }

    private void Start()
    {
        // Get handles
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _animator.SetFloat("Velocity", _rb.velocity.magnitude); 
    }
}
