
using UnityEngine;

public class Snowflake : Projectile
{
   [SerializeField] private GameObject _explosionEffect;

    public override void OnCollisionEnd()
    {
        Instantiate(_explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
