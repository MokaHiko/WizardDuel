using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : IDamaging
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    // Start is called before the first frame update
    public void Start()
    {
        foreach(Collider2D col in Physics2D.OverlapCircleAll(transform.position, _radius))
        {
            if(col.TryGetComponent<IDamageable>(out var damageable))
            {
                Debug.Log(col.gameObject);
                damageable.Knockback((col.transform.position - transform.position) * _force);
                damageable.TakeDamage(this);
            }
        }
    }
}
