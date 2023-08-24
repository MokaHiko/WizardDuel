using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

[RequireComponent(typeof(CircleCollider2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private Element _element;
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float _speed;

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Launch(Vector2 dir)
    {
        _rb.AddForce(dir * _speed, ForceMode2D.Impulse);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionCallback();
    }

    public virtual void CollisionCallback()
    {
        Destroy(gameObject);
    }
}
