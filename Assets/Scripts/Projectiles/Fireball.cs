using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{
    [SerializeField] private GameObject _explosionEffect;

    public override void CollisionCallback()
    {
        Instantiate(_explosionEffect, transform.position, transform.rotation);
        //Destroy(gameObject);
    }

}
