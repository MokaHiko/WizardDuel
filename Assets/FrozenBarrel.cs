using System.Collections;
using UnityEngine;

public class FrozenBarrel : IDamageable
{
    [SerializeField] private float _duration;
    [SerializeField] GameObject _explosionPrefab;

    private Coroutine _explodeCoroutine = null;

    public override void OnTakeDamage()
    {
        if(_health > 0)
        {
            return;
        }

        if(_explodeCoroutine != null)
        {
            StopCoroutine(_explodeCoroutine);
            Explode();
        }
    }

    public void OnEnable()
    {
        if(_explodeCoroutine == null)
        {
            _explodeCoroutine = StartCoroutine(ExplodeProcess());
        }
    }

    private IEnumerator ExplodeProcess()
    {
        yield return new WaitForSeconds(_duration);
        Explode();
    }
    private void Explode()
    {
        Instantiate(_explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
