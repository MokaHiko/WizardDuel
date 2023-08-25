using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterCombat : MonoBehaviour
{
    [Header("Combat")]
    [SerializeField] private Transform _castPoint;
    [SerializeField] private float _spellCastCoolDown;
    [SerializeField] private ElementInfo _elementInfo;
    [SerializeField] Vector2 _targetDir;

    private float _timeSinceLastSpell;

    [Header("Animation")]
    [SerializeField] private CharacterAnimation _characterAnimation;
    [SerializeField] private Animator _animator;

    private Character _character;

    public void SetElementInfo(ElementInfo element)
    {
        _elementInfo = element;
    }

    private void Start()
    {
        _character = GetComponent<Character>();
        _characterAnimation.AttackPoint.AddListener(() =>
        {
            FireProjectile();
        });

        _timeSinceLastSpell = _spellCastCoolDown;
    }

    public void Update()
    {
        _timeSinceLastSpell += Time.deltaTime;
    }

    public void BasicCast(Vector2 dir)
    {
        if(_timeSinceLastSpell < _spellCastCoolDown)
        {
            return;
        }

        _timeSinceLastSpell = 0;
        _targetDir = dir;
        _animator.SetTrigger("BasicCast");
    }

    private void FireProjectile()
    {
        Projectile projectile = Instantiate(_elementInfo.BasicAttackProjectile, _castPoint.transform.position, _castPoint.transform.rotation).GetComponent<Projectile>();
        projectile.Launch(_targetDir);
    }

    public IEnumerator CastBasicProcess()
    {
        yield break;
    }
}
