using UnityEngine;
using UnityEngine.Events;

public class CharacterAnimation : MonoBehaviour
{
    public UnityEvent AttackBegin;
    public UnityEvent AttackPoint;
    public UnityEvent AttackEnd;

    public void OnAttackBegin()
    {
        AttackBegin.Invoke();
    }

    public void OnAttackPoint()
    {
        AttackPoint.Invoke();
    }

    public void OnAttackEnd()
    {
        AttackPoint.Invoke();
    }
}
