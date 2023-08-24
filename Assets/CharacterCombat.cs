using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Character))]
[RequireComponent(typeof(Animator))]
public class CharacterCombat : MonoBehaviour
{
    [Header("Combat")]
    [SerializeField] private Transform _castPoint;
    [SerializeField] private float _spellCastCoolDown;
    [SerializeField] private ElementInfo _elementInfo;

    private Animator _animator;
    private Character _character;

    private void Start()
    {
        _character = GetComponent<Character>();
        _animator = GetComponent<Animator>();
    }

    public void BasicCast(Vector2 dir)
    {
        _animator.SetTrigger("BasicCast");
        FireProjectile(dir);
    }

    private void FireProjectile(Vector2 dir)
    {
        Vector3 castPoint = dir;
        Projectile projectile = Instantiate(_elementInfo.BasicAttackProjectile, _castPoint.transform.position, _castPoint.transform.rotation).GetComponent<Projectile>();
        projectile.Launch(dir);
        _character.GetDirection();
    }

    public IEnumerator CastBasicProcess()
    {
        yield break;
    }
}
