using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Projectile : IDamaging
{
    [Header("Projectile")]
    [SerializeField] private float _speed;

    private Rigidbody2D _rb;
    
    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Launch(Vector2 dir)
    {
        _rb.AddForce(dir * _speed, ForceMode2D.Impulse);
    }
}
