using UnityEngine;

public class IDamaging : MonoBehaviour
{
    [Header("IDamaging")]
    [SerializeField] public int Damage;
    [SerializeField] public Element DamageElement;

    /// <summary>
    /// Called after IDamaging object has dealt damage
    /// </summary>
    public virtual void OnDealDamage()
    {

    }

    public virtual void OnCollisionEnd()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            OnDealDamage();
            damageable.TakeDamage(this);
        }

        OnCollisionEnd();
    }
}
