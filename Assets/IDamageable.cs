using System.Collections.Generic;
using UnityEngine;

public enum DestructableMaterial
{
    Unknown,
    Flesh,
    Wood,
    Steel,
}

[System.Serializable]
public class ElementalDamagePrefab
{
    public Element Element;
    public GameObject DamagedPrefab;
}

[RequireComponent(typeof(Rigidbody2D))]
public class IDamageable : MonoBehaviour
{
    [Header("IDamageable")]
    [SerializeField] protected float _health;
    [SerializeField] private DestructableMaterial _destructableMaterial;
    [SerializeField] private List<ElementalDamagePrefab> _damagedPrefabs;

    public virtual void OnTakeDamage()
    {

    }

    public void Knockback(Vector2 force)
    {
        GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }

    public void TakeDamage(IDamaging dmgDealer)
    {
        _health -= dmgDealer.Damage;
        OnTakeDamage();

        ElementalDamagePrefab elementalDamagePrefab= _damagedPrefabs.Find(dmgPrefab => dmgPrefab.Element == dmgDealer.DamageElement);
        if(elementalDamagePrefab != null) 
        {
            Instantiate(elementalDamagePrefab.DamagedPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
